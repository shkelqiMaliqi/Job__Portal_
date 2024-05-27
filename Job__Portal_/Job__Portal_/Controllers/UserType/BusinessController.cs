using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models.UserType;
using Job__Portal_.Models;

namespace Job__Portal_.Controllers.UserType
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public string SessionKeyName { get; private set; }

        public BusinessController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // BusinessUser Create
        [HttpPost]
        public IActionResult Post(Business b)
        {
            string query = @"
                INSERT INTO dbo.BusinessUser (B_CompanyName, B_Email, B_PhoneNumber, B_Password, B_RepeatPassword, UserType_Id)
                VALUES (@B_CompanyName, @B_Email, @B_PhoneNumber, @B_Password, @B_RepeatPassword, @UserType_Id)
            ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@B_CompanyName", b.B_CompanyName);
                    myCommand.Parameters.AddWithValue("@B_Email", b.B_Email);
                    myCommand.Parameters.AddWithValue("@B_PhoneNumber", b.B_PhoneNumber);
                    myCommand.Parameters.AddWithValue("@B_Password", b.B_Password);
                    myCommand.Parameters.AddWithValue("@B_RepeatPassword", b.B_RepeatPassword);
                    myCommand.Parameters.AddWithValue("@UserType_Id", b.UserType_Id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201, "Business user registered successfully");
        }

        // Business Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                SELECT B_Id, B_CompanyName, B_Email, B_PhoneNumber, B_Password, B_RepeatPassword, UserType_Id 
                FROM dbo.BusinessUser
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }
                myCon.Close();
            }
            return new JsonResult(table);
        }

        // Business Update
        [HttpPut]
        public IActionResult Put(Business b)
        {
            string query = @"
                UPDATE dbo.BusinessUser
                SET B_CompanyName = @B_CompanyName,
                    B_Email = @B_Email,
                    B_PhoneNumber = @B_PhoneNumber,
                    B_Password = @B_Password,
                    B_RepeatPassword = @B_RepeatPassword,
                    UserType_Id = @UserType_Id
                WHERE B_Id = @B_Id
            ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@B_Id", b.B_Id);
                    myCommand.Parameters.AddWithValue("@B_CompanyName", b.B_CompanyName);
                    myCommand.Parameters.AddWithValue("@B_Email", b.B_Email);
                    myCommand.Parameters.AddWithValue("@B_PhoneNumber", b.B_PhoneNumber);
                    myCommand.Parameters.AddWithValue("@B_Password", b.B_Password);
                    myCommand.Parameters.AddWithValue("@B_RepeatPassword", b.B_RepeatPassword);
                    myCommand.Parameters.AddWithValue("@UserType_Id", b.UserType_Id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(200, "Business user updated successfully");
        }

        // Business Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                DELETE FROM dbo.BusinessUser
                WHERE B_Id = @B_Id
            ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@B_Id", id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(200, "Business user deleted successfully");
        }

        [HttpPost("login")]
        public IActionResult BusinessLogin(LoginModel login)
        {
            string query = @"SELECT B_Id, B_Email FROM dbo.BusinessUser WHERE B_Email = @B_Email AND B_Password = @B_Password";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@B_Email", login.U_Email);
                    myCommand.Parameters.AddWithValue("@B_Password", login.U_Password);

                    myCon.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        int businessId = reader.GetInt32(0);
                        string email = reader.GetString(1);


                        HttpContext.Session.SetInt32(SessionKeyName, businessId);

                        return Ok(new { BusinessId = businessId, B_Email = email });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKeyName);
            return Ok("Logged out successfully");
        }

    }
}
