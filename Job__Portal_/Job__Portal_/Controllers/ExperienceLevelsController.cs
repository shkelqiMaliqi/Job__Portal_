using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models;

namespace Job__Portal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceLevelsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ExperienceLevelsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get all experience levels
        [HttpGet]
        public IActionResult Get()
        {
            string query = "SELECT * FROM ExperienceLevels";
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                SqlDataReader myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }

            return new JsonResult(table);
        }

        // Create a new experience level
        [HttpPost]
        public IActionResult Post(ExperienceLevel experienceLevel)
        {
            string query = @"INSERT INTO ExperienceLevels (LevelName) 
                             VALUES (@LevelName)";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@LevelName", experienceLevel.LevelName);

                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return StatusCode(201, "Experience level created successfully.");
        }

        // Update an existing experience level
        [HttpPut("{id}")]
        public IActionResult Put(int id, ExperienceLevel experienceLevel)
        {
            string query = @"UPDATE ExperienceLevels 
                             SET LevelName = @LevelName 
                             WHERE ExperienceLevelId = @ExperienceLevelId";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);

                myCommand.Parameters.AddWithValue("@ExperienceLevelId", id);
                myCommand.Parameters.AddWithValue("@LevelName", experienceLevel.LevelName);
                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return Ok("Experience level updated successfully.");
        }

        // Delete a specific experience level
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"DELETE FROM ExperienceLevels 
                             WHERE ExperienceLevelId = @ExperienceLevelId";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@ExperienceLevelId", id);
                myCommand.ExecuteNonQuery();
                myCon.Close();
            }


            return Ok("Experience level deleted successfully.");
        }
    }
}
