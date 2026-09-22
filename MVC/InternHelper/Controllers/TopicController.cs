using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace InternHelper.Controllers
{
    public class TopicController : Controller
    {
        private readonly NpgsqlConnection _connection;

        public TopicController(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IActionResult> Index()
        {
            List<Topic> topics = new List<Topic>();

            await _connection.OpenAsync();

            string query = "Select c_topicid,c_topicname from t_topics order by c_topicid";

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

            // to check whether the data is fetching correctly

            // return Content(
            //     string.Join(
            //         Environment.NewLine,
            //         topics.Select(t => $"{t.TopicId} - {t.TopicName}")
            //     )
            // );

            return View(topics);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Topic topic)
        {
            await _connection.OpenAsync();

            string query = @"insert into t_topics (c_topicname) values (@topicName)";

            using NpgsqlCommand command = new NpgsqlCommand(query,_connection);

            command.Parameters.AddWithValue("@topicName",topic.TopicName);

            await command.ExecuteNonQueryAsync();

            await _connection.CloseAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await _connection.OpenAsync();

            string query  = @"select c_topicid,c_topicname from t_topics where c_topicid = @id";

            using NpgsqlCommand command = new NpgsqlCommand(query,_connection);

            command.Parameters.AddWithValue("@id",id);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if(!await reader.ReadAsync())
            {
                await _connection.CloseAsync();
                return NotFound();
            }

            Topic topic = new Topic
            {
                TopicId = reader.GetInt32(0),
                TopicName = reader.GetString(1)
            };

            await _connection.CloseAsync();

            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Topic topic)
        {
            await _connection.OpenAsync();

            string query = @"update t_topics set c_topicname = @topicName where c_topicid = @topicId ";

            using NpgsqlCommand command = new NpgsqlCommand(query,_connection);

            command.Parameters.AddWithValue("@topicName",topic.TopicName);
            command.Parameters.AddWithValue("@topicId",topic.TopicId);

            await command.ExecuteNonQueryAsync();

            await _connection.CloseAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _connection.OpenAsync();

            string query = @"Select c_topicid,c_topicname from t_topics where c_topicid = @id";

            using NpgsqlCommand command  = new NpgsqlCommand(query,_connection);

            command.Parameters.AddWithValue("@id",id);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if(!await reader.ReadAsync()){
                await _connection.CloseAsync();
                return NotFound();
            }

            Topic topic = new Topic
            {
                TopicId = reader.GetInt32(0),
                TopicName = reader.GetString(1)
            };

            await _connection.CloseAsync();

            return View(topic);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Topic topic)
        {
            await _connection.OpenAsync();

            string query  = @"delete from t_topics where c_topicid = @topicId ";

            using NpgsqlCommand command = new NpgsqlCommand(query,_connection);

            command.Parameters.AddWithValue("@topicId",topic.TopicId);

            await command.ExecuteNonQueryAsync();

            await _connection.CloseAsync();

            return RedirectToAction("Index");
        }
    }
}