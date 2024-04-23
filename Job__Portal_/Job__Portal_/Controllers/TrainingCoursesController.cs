using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models;

namespace Job__Portal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCoursesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TrainingCoursesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get all training courses
        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM TrainingCourses";
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

        // Create a new training course
        [HttpPost]
        public IActionResult Post(TrainingCourse course)
        {
            string query = @"INSERT INTO TrainingCourses (Title, Description, StartDate, EndDate, Instructor, Price) 
                             VALUES (@Title, @Description, @StartDate, @EndDate, @Instructor, @Price)";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@Title", course.Title);
                myCommand.Parameters.AddWithValue("@Description", course.Description);
                myCommand.Parameters.AddWithValue("@StartDate", course.StartDate);
                myCommand.Parameters.AddWithValue("@EndDate", course.EndDate);
                myCommand.Parameters.AddWithValue("@Instructor", course.Instructor);
                myCommand.Parameters.AddWithValue("@Price", course.Price);

                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return StatusCode(201, "Training course created successfully.");
        }

        // Update an existing training course
        [HttpPut("{id}")]
        public IActionResult Put(int id, TrainingCourse course)
        {
            string query = @"UPDATE TrainingCourses 
                             SET Title = @Title, Description = @Description, StartDate = @StartDate, EndDate = @EndDate, Instructor = @Instructor, Price 
                             WHERE TrainingCourseId = @TrainingCourseId";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);

                myCommand.Parameters.AddWithValue("@TrainingCourseId", id);
                myCommand.Parameters.AddWithValue("@Title", course.Title);
                myCommand.Parameters.AddWithValue("@Description", course.Description);
                myCommand.Parameters.AddWithValue("@StartDate", course.StartDate);
                myCommand.Parameters.AddWithValue("@EndDate", course.EndDate);
                myCommand.Parameters.AddWithValue("@Instructor", course.Instructor);
                myCommand.Parameters.AddWithValue("@Price", course.Price);

                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return Ok("Training course updated successfully.");
        }

        // Delete a specific training course
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"DELETE FROM TrainingCourses WHERE TrainingCourseId = @TrainingCourseId";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@TrainingCourseId", id);
                cmd.ExecuteNonQuery();
                myCon.Close();
            }

            return Ok("Training course deleted successfully.");
        }
    }
}
