using Microsoft.AspNetCore.Mvc;
using Npgsql;
using InternHelper.Models;

namespace InternHelper.Controllers
{
    public class InternController : Controller
    {
        private readonly NpgsqlConnection _connection;

        public InternController(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IActionResult> Index()
        {
            List<Intern> interns = new List<Intern>();

            await _connection.OpenAsync();

            string query = @"SELECT
                            i.c_internid,
                            i.c_internname,
                            i.c_gender,
                            i.c_topicid,
                            t.c_topicname,
                            i.c_date_of_presentation,
                            i.c_status,
                            i.c_topic_image
                        FROM t_internsdemo i
                        INNER JOIN t_topics t
                            ON i.c_topicid = t.c_topicid
                        ORDER BY i.c_internid
                    ";

            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Intern intern = new Intern
                {
                    InternId = reader.GetInt32(0),
                    InternName = reader.GetString(1),
                    Gender = reader.GetString(2),
                    TopicId = reader.GetInt32(3),
                    TopicName = reader.GetString(4),
                    DateOfPresentation = reader.GetDateTime(5),
                    Status = reader.GetBoolean(6),
                    TopicImage = reader.IsDBNull(7) ? null : reader.GetString(7)
                };

                interns.Add(intern);
            }

            await _connection.CloseAsync();

            return View(interns);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Topic> topics = new List<Topic>();

            await _connection.OpenAsync();

            string query = @"Select c_topicid,c_topicname from t_topics order by c_topicid";

            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Topic topic = new Topic
                {
                    TopicId = reader.GetInt32(0),
                    TopicName = reader.GetString(1)
                };
                topics.Add(topic);
            }

            await _connection.CloseAsync();

            ViewBag.Topics = topics;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Intern intern)
        {
            await _connection.OpenAsync();

            string query = @"Insert into t_internsdemo(c_internname,c_gender,c_topicid,c_date_of_presentation,c_status,c_topic_image)values (@internName,@gender,@topicId,@dateOfPresentation,@status,@topicImage)";

            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            command.Parameters.AddWithValue("@internName", intern.InternName);
            command.Parameters.AddWithValue("@gender", intern.Gender);
            command.Parameters.AddWithValue("@topicId", intern.TopicId);
            command.Parameters.AddWithValue("@dateOfPresentation", intern.DateOfPresentation);
            command.Parameters.AddWithValue("@status", intern.Status);
            command.Parameters.AddWithValue("@topicImage", (object?)intern.TopicImage ?? DBNull.Value);

            await command.ExecuteNonQueryAsync();

            await _connection.CloseAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await _connection.OpenAsync();

            string query = @"Select c_internid,c_internname,c_gender,c_topicid,c_date_of_presentation,c_status,c_topic_image from t_internsdemo where c_internid = @id";

            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            command.Parameters.AddWithValue("@id", id);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                await _connection.CloseAsync();

                return NotFound();
            }

            Intern intern = new Intern
            {
                InternId = reader.GetInt32(0),
                InternName = reader.GetString(1),
                Gender = reader.GetString(2),
                TopicId = reader.GetInt32(3),
                DateOfPresentation = reader.GetDateTime(4),
                Status = reader.GetBoolean(5),
                TopicImage = reader.IsDBNull(6) ? null : reader.GetString(6)
            };

            await _connection.CloseAsync();

            await _connection.OpenAsync();

            string topicQuery = @"Select c_topicid,c_topicname from t_topics order by c_topicid";

            using NpgsqlCommand command1 = new NpgsqlCommand(topicQuery, _connection);

            using NpgsqlDataReader reader1 = await command1.ExecuteReaderAsync();

            List<Topic> topics = new List<Topic>();

            while (await reader1.ReadAsync())
            {
                Topic topic = new Topic
                {
                    TopicId = reader1.GetInt32(0),
                    TopicName = reader1.GetString(1)
                };

                topics.Add(topic);
            }

            await _connection.CloseAsync();

            ViewBag.Topics = topics;

            return View(intern);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Intern intern)
        {
            await _connection.OpenAsync();

            string query = @"update t_internsdemo set c_internname = @internName,c_gender = @gender, c_topicid = @topicId,c_date_of_presentation = @dateOfPresentation,c_status = @status,c_topic_image = @topicImage where c_internid = @internId";
            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            command.Parameters.AddWithValue("@internName", intern.InternName);
            command.Parameters.AddWithValue("@gender", intern.Gender);
            command.Parameters.AddWithValue("@topicId", intern.TopicId);
            command.Parameters.AddWithValue("@status", intern.Status);
            command.Parameters.AddWithValue("@dateOfPresentation", intern.DateOfPresentation);
            command.Parameters.AddWithValue("@topicImage", (object?)intern.TopicImage ?? DBNull.Value);
            command.Parameters.AddWithValue("@internId", intern.InternId);

            await command.ExecuteNonQueryAsync();

            await _connection.CloseAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _connection.OpenAsync();

            string query = @"
        SELECT
            c_internid,
            c_internname,
            c_gender,
            c_topicid,
            c_date_of_presentation,
            c_status,
            c_topic_image
        FROM t_internsdemo
        WHERE c_internid = @id
    ";

            using NpgsqlCommand command =
                new NpgsqlCommand(query, _connection);

            command.Parameters.AddWithValue("@id", id);

            using NpgsqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                await _connection.CloseAsync();
                return NotFound();
            }

            Intern intern = new Intern
            {
                InternId = reader.GetInt32(0),
                InternName = reader.GetString(1),
                Gender = reader.GetString(2),
                TopicId = reader.GetInt32(3),
                DateOfPresentation = reader.GetDateTime(4),
                Status = reader.GetBoolean(5),
                TopicImage = reader.IsDBNull(6)
                    ? null
                    : reader.GetString(6)
            };

            await _connection.CloseAsync();

            return View(intern);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Intern intern)
        {
            await _connection.OpenAsync();

            string query = @"
        DELETE FROM t_internsdemo
        WHERE c_internid = @internId
    ";

            using NpgsqlCommand command =
                new NpgsqlCommand(query, _connection);

            command.Parameters.AddWithValue(
                "@internId",
                intern.InternId
            );

            await command.ExecuteNonQueryAsync();

            await _connection.CloseAsync();

            return RedirectToAction("Index");
        }
    }
}