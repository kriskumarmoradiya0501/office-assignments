using System.Collections.Generic;
using System.IO;
using Intern.Models;
using Microsoft.AspNetCore.Http;
using Npgsql;

namespace Intern.Services;

public class InternHelper
{

    private readonly NpgsqlConnection _conn;
    private readonly string _imagePath;


    public InternHelper(NpgsqlConnection connection)
    {
        _conn = connection;
        _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        if (!Directory.Exists(_imagePath))
        {
            Directory.CreateDirectory(_imagePath);
        }
    }

    public List<InterClass> FetchAllInterns()
    {
        _conn.Open();
        using var command = new NpgsqlCommand(@"
        SELECT i.*, t.c_topicname
        FROM public.t_intern i
        LEFT JOIN public.t_topic t ON i.c_topicid = t.c_topicid ORDER BY i.c_internid", _conn);

        var interns = new List<InterClass>();
        
        using var reader = command.ExecuteReader();


        while (reader.Read())
        {
            interns.Add(new InterClass
            {
                InternId = Convert.ToInt32(reader["c_internid"]),
                InternName = reader["c_internname"].ToString(),
                Gender = reader["c_gender"].ToString(),
                TopicId = Convert.ToInt32(reader["c_topicid"]),
                DateOfPresentation = reader.IsDBNull(reader.GetOrdinal("c_date"))
                    ? null
                    : reader.GetFieldValue<DateOnly>(reader.GetOrdinal("c_date")),
                Status = Convert.ToBoolean(reader["c_status"]),
                TopicImage = reader["c_topic_image"] as string,
                AssignedTopic = new TopicClass // Create and populate the TopicClass object
                {
                    TopicId = Convert.ToInt32(reader["c_topicid"]), // Assuming you get the topic ID
                    TopicName = reader["c_topicname"]?.ToString() // Assuming you get the topic name
                }
            });
        }


        _conn.Close();
        return interns;
    }
    public List<TopicClass> FetchAllTopics()
        {
            var topics = new List<TopicClass>();
            _conn.Open();


            using var command = new NpgsqlCommand("SELECT c_topicid, c_topicname FROM public.t_topic", _conn);
            using var reader = command.ExecuteReader();


            while (reader.Read())
            {
                topics.Add(new TopicClass
                {
                    TopicId = Convert.ToInt32(reader["c_topicid"]),
                    TopicName = reader["c_topicname"].ToString()
                });
            }


            _conn.Close();
            return topics;
        }

    public InterClass? FetchInternDetails(int id)
        {
            InterClass? intern = null;
            _conn.Open();


            // Query with a join to fetch the topic name along with the intern details
            using var command = new NpgsqlCommand(@"
        SELECT i.*, t.c_topicname
        FROM public.t_intern i
        LEFT JOIN public.t_topic t ON i.c_topicid = t.c_topicid
        WHERE i.c_internid = @id", _conn);


            command.Parameters.AddWithValue("@id", id);


            using var reader = command.ExecuteReader();


            if (reader.Read())
            {
                intern = new InterClass
                {
                    InternId = Convert.ToInt32(reader["c_internid"]),
                    InternName = reader["c_internname"].ToString(),
                    Gender = reader["c_gender"].ToString(),
                    TopicId = Convert.ToInt32(reader["c_topicid"]),
                    AssignedTopic = new TopicClass // Add the assigned topic
                    {
                        TopicId = Convert.ToInt32(reader["c_topicid"]),
                        TopicName = reader["c_topicname"].ToString()
                    },
                    DateOfPresentation = reader.IsDBNull(reader.GetOrdinal("c_date"))
                        ? null
                        : reader.GetFieldValue<DateOnly>(reader.GetOrdinal("c_date")),
                    Status = Convert.ToBoolean(reader["c_status"]),
                    TopicImage = reader["c_topic_image"] as string
                };
            }
                _conn.Close();
            return intern;
        }
    public void AddNewIntern(InterClass intern)
        {
           

            using var command = new NpgsqlCommand(@"
        INSERT INTO t_intern
        (c_internname, c_gender, c_topicid, c_date, c_status, c_topic_image)
        VALUES (@InternName, @Gender, @TopicId, @DateOfPresentation, @Status, @TopicImage)", _conn);


            command.Parameters.AddWithValue("@InternName", (object?)intern.InternName ?? DBNull.Value);
            command.Parameters.AddWithValue("@Gender", (object?)intern.Gender ?? DBNull.Value);
            command.Parameters.AddWithValue("@TopicId", (object?)intern.TopicId ?? DBNull.Value);
            command.Parameters.AddWithValue("@DateOfPresentation", (object?)intern.DateOfPresentation ?? DBNull.Value);
            command.Parameters.AddWithValue("@Status", intern.Status);
            command.Parameters.AddWithValue("@TopicImage", (object?)intern.TopicImage ?? DBNull.Value); // Allow null image


            _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
        }

    public void UpdateExistingIntern(InterClass intern)
        {
            _conn.Open();
            using var command = new NpgsqlCommand(@"
        UPDATE t_intern
        SET
            c_internname = @InternName,
            c_gender = @Gender,
            c_topicid = @TopicId,
            c_date = @DateOfPresentation,
            c_status = @Status,
            c_topic_image = @TopicImage
        WHERE c_internid = @InternId", _conn);


            command.Parameters.AddWithValue("@InternId", intern.InternId);
            command.Parameters.AddWithValue("@InternName", (object?)intern.InternName ?? DBNull.Value);
            command.Parameters.AddWithValue("@Gender", (object?)intern.Gender ?? DBNull.Value);
            command.Parameters.AddWithValue("@TopicId", (object?)intern.TopicId ?? DBNull.Value);
            command.Parameters.AddWithValue("@DateOfPresentation", (object?)intern.DateOfPresentation ?? DBNull.Value);
            command.Parameters.AddWithValue("@Status", intern.Status);
            command.Parameters.AddWithValue("@TopicImage", (object?)intern.TopicImage ?? DBNull.Value);
            command.ExecuteNonQuery();
            _conn.Close();
        }

    public string SaveImage(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        if (!allowedExtensions.Contains(extension))
        {
            throw new ArgumentException("Only JPG, JPEG, PNG, GIF, and WEBP images are allowed.");
        }

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var filePath = Path.Combine(_imagePath, fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);
        return fileName;
    }

    public void DeleteImage(string? fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return;
        }

        var imagePath = Path.Combine(_imagePath, Path.GetFileName(fileName));
        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }
    }

    public void DeleteExistingIntern(int id)
        {
            
            var intern = FetchInternDetails(id);

            if (intern?.TopicImage != null)
            {
                DeleteImage(intern.TopicImage);
            }


            using var command = new NpgsqlCommand("DELETE FROM t_intern WHERE c_internid = @id", _conn);
            command.Parameters.AddWithValue("@id", id);


            _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
        }


}
