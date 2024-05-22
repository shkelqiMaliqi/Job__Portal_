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
    public class CousesApplyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TrainingCoursesController> _logger;
        private readonly IWebHostEnvironment _env;

        public CousesApplyController(IConfiguration configuration, ILogger<TrainingCoursesController> logger, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _logger = logger;
            _env = env;
        }

        // -------------------------- CREATE ------------------
        [HttpPost]
        public IActionResult Post([FromBody] CoursesApply apply)
        {
            if (apply == null)
            {
                return BadRequest("Invalid course data.");
            }

            string query = @"
           INSERT INTO dbo.CourseApplyForm
           (Attendant_Name, Attendant_Surname, Attendant_Email, Attendant_PhoneNo, Courses_ApplyingName) 
            VALUES 
           (@Attendant_Name, @Attendant_Surname, @Attendant_Email, @Attendant_PhoneNo, @Courses_ApplyingName)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Attendant_Name", apply.Attendant_Name);
                    myCommand.Parameters.AddWithValue("@Attendant_Surname", apply.Attendant_Surname);
                    myCommand.Parameters.AddWithValue("@Attendant_Email", apply.Attendant_Email);
                    myCommand.Parameters.AddWithValue("@Attendant_PhoneNo", apply.Attendant_PhoneNo);
                    myCommand.Parameters.AddWithValue("@Courses_ApplyingName", apply.Courses_ApplyingName);
           

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
                   CourseApplyId, Attendant_Name, Attendant_Surname, Attendant_Email, Attendant_PhoneNo, Courses_ApplyingName
            FROM dbo.CourseApplyForm";

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
        public IActionResult Put(int id, [FromBody] CoursesApply apply)
        {
            if (apply == null)
            {
                return BadRequest("Invalid course data.");
            }

            string query = @"
                    UPDATE dbo.CourseApplyForm
                    SET
                    Attendant_Name = @Attendant_Name,                    
                    Attendant_Surname = @Attendant_Surname, 
                    Attendant_Email = @Attendant_Email,
                    Attendant_PhoneNo = @Attendant_PhoneNo,
                    Courses_ApplyingName = @Courses_ApplyingName, 
                    WHERE CourseApplyId = @CourseApplyId";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))

                myCommand.Parameters.AddWithValue("@CourseApplyId", CourseApplyId);
                myCommand.Parameters.AddWithValue("@Attendant_Name", apply.Attendant_Name);
                myCommand.Parameters.AddWithValue("@Attendant_Surname", apply.Attendant_Surname);
                myCommand.Parameters.AddWithValue("@Attendant_Email", apply.Attendant_Email);
                myCommand.Parameters.AddWithValue("@Attendant_PhoneNo", apply.Attendant_PhoneNo);
                myCommand.Parameters.AddWithValue("@Courses_ApplyingName", apply.Courses_ApplyingName);
               

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
                    DELETE FROM dbo.CourseApplyForm
                    WHERE CourseApplyId = @CourseApplyId";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CourseApplyId", id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("Training course deleted successfully.");
        }

    }
}