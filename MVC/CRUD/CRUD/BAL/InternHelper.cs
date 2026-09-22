using System;
using System.Collections.Generic;
using System.IO;
using Crud_Ajax.Models;
using Npgsql;

namespace Crud_Ajax.BAL
{
    public class InternHelper
    {
        private readonly NpgsqlConnection _conn;
        private readonly string _imagePath;

        public InternHelper(NpgsqlConnection connection)
        {
            _conn = connection;
            _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            // Create the images directory if it doesn't exist
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(_imagePath);
            }
        }

        public List<InternClass> FetchAllInterns()
        {
            var interns = new List<InternClass>();
            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();

            // Adjust the SQL query to join with the topic table
            using var command = new NpgsqlCommand(@"
                SELECT i.*, t.c_topicname
                FROM public.t_internsdemo i
                LEFT JOIN public.t_topics t ON i.c_topicid = t.c_topicid ORDER BY i.c_internid", _conn);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateOnly dateVal;
                var rawDate = reader["c_date_of_presentation"];
                if (rawDate is DateOnly d)
                    dateVal = d;
                else if (rawDate is DateTime dt)
                    dateVal = DateOnly.FromDateTime(dt);
                else
                    dateVal = DateOnly.FromDateTime(Convert.ToDateTime(rawDate));

                interns.Add(new InternClass
                {
                    InternId = Convert.ToInt32(reader["c_internid"]),
                    InternName = reader["c_internname"].ToString(),
                    Gender = reader["c_gender"].ToString(),
                    TopicId = Convert.ToInt32(reader["c_topicid"]),
                    DateOfPresentation = dateVal,
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
            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();

            using var command = new NpgsqlCommand("SELECT c_topicid, c_topicname FROM public.t_topics", _conn);
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

        public InternClass FetchInternDetails(int id)
        {
            InternClass intern = null;
            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();

            // Query with a join to fetch the topic name along with the intern details
            using var command = new NpgsqlCommand(@"
                SELECT i.*, t.c_topicname
                FROM public.t_internsdemo i
                LEFT JOIN public.t_topics t ON i.c_topicid = t.c_topicid
                WHERE i.c_internid = @id", _conn);
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                DateOnly dateVal;
                var rawDate = reader["c_date_of_presentation"];
                if (rawDate is DateOnly d)
                    dateVal = d;
                else if (rawDate is DateTime dt)
                    dateVal = DateOnly.FromDateTime(dt);
                else
                    dateVal = DateOnly.FromDateTime(Convert.ToDateTime(rawDate));

                intern = new InternClass
                {
                    InternId = Convert.ToInt32(reader["c_internid"]),
                    InternName = reader["c_internname"].ToString(),
                    Gender = reader["c_gender"].ToString(),
                    TopicId = Convert.ToInt32(reader["c_topicid"]),
                    AssignedTopic = new TopicClass // Add the assigned topic
                    {
                        TopicId = Convert.ToInt32(reader["c_topicid"]),
                        TopicName = reader["c_topicname"]?.ToString()
                    },
                    DateOfPresentation = dateVal,
                    Status = Convert.ToBoolean(reader["c_status"]),
                    TopicImage = reader["c_topic_image"] as string
                };
            }
            _conn.Close();
            return intern;
        }

        public void AddNewIntern(InternClass intern)
        {
            // // Save the new image if provided
            // if (intern.TopicImageFile != null && intern.TopicImageFile.Length > 0)
            // {
            // intern.TopicImage = SaveImage(intern.TopicImageFile);
            // }
            using var command = new NpgsqlCommand(@"
                INSERT INTO t_InternsDemo 
                (c_internname, c_gender, c_topicid, c_date_of_presentation, c_status, c_topic_image)
                VALUES (@InternName, @Gender, @TopicId, @DateOfPresentation, @Status, @TopicImage)", _conn);

            command.Parameters.AddWithValue("@InternName", intern.InternName);
            command.Parameters.AddWithValue("@Gender", intern.Gender);
            command.Parameters.AddWithValue("@TopicId", intern.TopicId);
            command.Parameters.AddWithValue("@DateOfPresentation", intern.DateOfPresentation);
            command.Parameters.AddWithValue("@Status", intern.Status);
            command.Parameters.AddWithValue("@TopicImage", (object)intern.TopicImage ?? DBNull.Value); // Allow null image

            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public void UpdateExistingIntern(InternClass intern)
        {
            // // If a new image is provided, delete the old one and update
            // if (intern.TopicImageFile != null && intern.TopicImageFile.Length > 0)
            // {
            // // Save the new image
            // intern.TopicImage = SaveImage(intern.TopicImageFile);
            // }
            // else
            // {
            // // Keep the old image if no new image is uploaded
            // var existingIntern = FetchInternDetails(intern.InternId);
            // intern.TopicImage = existingIntern?.TopicImage;
            // }
            using var command = new NpgsqlCommand(@"
                UPDATE t_InternsDemo 
                SET
                    c_internname = @InternName,
                    c_gender = @Gender,
                    c_topicid = @TopicId,
                    c_date_of_presentation = @DateOfPresentation,
                    c_status = @Status,
                    c_topic_image = @TopicImage
                WHERE c_internid = @InternId", _conn);

            command.Parameters.AddWithValue("@InternId", intern.InternId);
            command.Parameters.AddWithValue("@InternName", intern.InternName);
            command.Parameters.AddWithValue("@Gender", intern.Gender);
            command.Parameters.AddWithValue("@TopicId", intern.TopicId);
            command.Parameters.AddWithValue("@DateOfPresentation", intern.DateOfPresentation);
            command.Parameters.AddWithValue("@Status", intern.Status);
            command.Parameters.AddWithValue("@TopicImage", (object)intern.TopicImage ?? DBNull.Value);

            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public void DeleteExistingIntern(int id)
        {
            // Optionally: Retrieve the intern's image path if you want to delete the image file
            var intern = FetchInternDetails(id);
            // if (intern?.TopicImage != null)
            // {
            // var imagePath = Path.Combine(_imagePath, Path.GetFileName(intern.TopicImage));
            // if (File.Exists(imagePath))
            // {
            // File.Delete(imagePath); // Delete the image file from the server
            // }
            // }

            using var command = new NpgsqlCommand("DELETE FROM t_InternsDemo WHERE c_internid = @id", _conn);
            command.Parameters.AddWithValue("@id", id);

            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
        }

        // public string SaveImage(IFormFile imageFile)
        // {
        // if (imageFile == null || imageFile.Length == 0)
        // {
        // return null; // No file provided
        // }
        // try
        // {
        // #region To store File Name
        // var fileName = Path.GetFileName(imageFile.FileName);
        // var filePath = Path.Combine(_imagePath, fileName);
        // #endregion
        // #region Generate unique file name (GUID + original extension)
        // // var extension = Path.GetExtension(imageFile.FileName);
        // // var uniqueFileName = $"{Guid.NewGuid()}{extension}";
        // // var filePath = Path.Combine(_imagePath, uniqueFileName);
        // #endregion
        // using (var stream = new FileStream(filePath, FileMode.Create))
        // {
        // imageFile.CopyTo(stream); // Save the uploaded file
        // }
        // Console.WriteLine($"Image saved successfully at {filePath}"); // Debugging output
        // return $"/images/{fileName}"; // Return the relative URL of the saved image
        // //return $"/images/{uniqueFileName}"; // Save only relative path in DB
        // //The DB only stores the relative path/URL so that Razor views can render <img src="@Model.TopicImage" />.
        // // return $"{uniqueFileName}";
        // //The DB only stores the relative Image from images folder views can render <img src="@Url.Content("~/images/" + Model.TopicImage)" alt="Intern Image" />.
        // }
        // catch (Exception ex)
        // {
        // Console.WriteLine($"Error saving image: {ex.Message}"); // Log any errors
        // return null; // Handle the error appropriately
        // }
        // }
    }
}
