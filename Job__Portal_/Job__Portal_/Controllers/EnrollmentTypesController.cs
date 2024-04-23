using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models;

namespace Job__Portal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentTypesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EnrollmentTypesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get all enrollment types
        [HttpGet]
        public IActionResult Get()
        {
            string query = "SELECT * FROM EnrollmentTypes";
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

        // Create a new enrollment type
        [HttpPost]
        public IActionResult Post(EnrollmentTypes enrollmentType)
        {
            string query = @"INSERT INTO EnrollmentTypes (TypeName) 
                             VALUES (@TypeName)";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@TypeName", enrollmentType.TypeName);

                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return StatusCode(201, "Enrollment type created successfully.");
        }

        // Update an existing enrollment type
        [HttpPut("{id}")]
        public IActionResult Put(int id, EnrollmentTypes enrollmentType)
        {
            string query = @"UPDATE EnrollmentTypes 
                             SET TypeName = @TypeName 
                             WHERE EnrollmentTypeId = @EnrollmentTypeId";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@EnrollmentTypeId", id);
                myCommand.Parameters.AddWithValue("@TypeName", enrollmentType.TypeName);

                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return Ok("Enrollment type updated successfully.");
        }

        // Delete a specific enrollment type
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"DELETE FROM EnrollmentTypes WHERE EnrollmentTypeId = @EnrollmentTypeId";

            string sqlDataSource = _configuration.GetConnectionString("ElvirConnection");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@EnrollmentTypeId", id);
                myCommand.ExecuteNonQuery();
                myCon.Close();
            }

            return Ok("Enrollment type deleted successfully.");
        }
    }
}
