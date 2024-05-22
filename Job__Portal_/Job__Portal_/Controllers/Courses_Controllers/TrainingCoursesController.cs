using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Job__Portal_.Models.Courses;

namespace Job__Portal_.Controllers.Courses_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCoursesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TrainingCoursesController> _logger;
        private readonly IWebHostEnvironment _env;

        public TrainingCoursesController(IConfiguration configuration, ILogger<TrainingCoursesController> logger, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _logger = logger;
            _env = env;
        }

        // -------------------------- CREATE ------------------
        [HttpPost]
        public IActionResult Post([FromBody] TrainingCourses course)
        {
            if (course == null)
            {
                return BadRequest("Invalid course data.");
            }

            string query = @"
           INSERT INTO TrainingCourses
           (Title, Description, StartDate, EndDate, Instructor, Price) 
     VALUES 
           (@Title, @Description, @StartDate, @EndDate, @Instructor, @Price)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Title", course.Title);
                    myCommand.Parameters.AddWithValue("@Description", course.Description);
                    myCommand.Parameters.AddWithValue("@StartDate", course.StartDate);
                    myCommand.Parameters.AddWithValue("@EndDate", course.EndDate);
                    myCommand.Parameters.AddWithValue("@Instructor", course.Instructor);
                    myCommand.Parameters.AddWithValue("@Price", course.Price);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(StatusCodes.Status201Created, "Training course created successfully.");
        }

        // ------------------------------ READ --------------------------
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            SELECT 
                   TrainingCourseId, Title, Description, StartDate, EndDate, Instructor, Price
            FROM TrainingCourses";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                }
            }

            return new JsonResult(table);
        }

        // --------------- UPDATE --------------------------------
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TrainingCourses course)
        {
            if (course == null)
            {
                return BadRequest("Invalid course data.");
            }

            string query = @"
                    UPDATE TrainingCourses
                    SET
                    Title = @Title,                    
                    Description = @Description, 
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    Instructor = @Instructor, 
                    Price = @Price
                    WHERE TrainingCourseId = @TrainingCourseId";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TrainingCourseId", id);
                    myCommand.Parameters.AddWithValue("@Title", course.Title);      
                    myCommand.Parameters.AddWithValue("@Description", course.Description);
                    myCommand.Parameters.AddWithValue("@StartDate", course.StartDate);
                    myCommand.Parameters.AddWithValue("@EndDate", course.EndDate);
                    myCommand.Parameters.AddWithValue("@Instructor", course.Instructor);
                    myCommand.Parameters.AddWithValue("@Price", course.Price);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("Training course updated successfully.");
        }

        // ---------------- DELETE --------------------------------
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    DELETE FROM TrainingCourses
                    WHERE TrainingCourseId = @TrainingCourseId";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TrainingCourseId", id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("Training course deleted successfully.");
        }

    }
}
