using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models;

namespace Job__Portal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string query = @"SELECT U_ID, U_Name, U_Surname, U_Email, U_Username, U_Phone, U_Password, U_RepeatPassword, U_Type FROM dbo.Users";

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string query = "SELECT * FROM dbo.Users WHERE U_Id = @U_Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Id", id);
                    myCon.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                    {
                        adapter.Fill(table);
                    }
                }
                myCon.Close();
            }
            if (table.Rows.Count == 1)
            {
                return Ok(table.Rows[0]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public IActionResult Post(Users userData)
        {
            string query = $@"
        INSERT INTO dbo.Users (U_Name, U_Surname, U_Email, U_Username, U_Phone, U_Password, U_RepeatPassword, U_Type)
        VALUES (@U_Name, @U_Surname, @U_Email, @U_Username, @U_Phone, @U_Password, @U_RepeatPassword, @U_Type)
    ";
             
            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand insertCmd = new SqlCommand(query, myCon))
                {
                    insertCmd.Parameters.AddWithValue("@U_Name", userData.U_Name);
                    insertCmd.Parameters.AddWithValue("@U_Surname", userData.U_Surname);
                    insertCmd.Parameters.AddWithValue("@U_Email", userData.U_Email);
                    insertCmd.Parameters.AddWithValue("@U_Username", userData.U_Username);
                    insertCmd.Parameters.AddWithValue("@U_Phone", userData.U_Phone);
                    insertCmd.Parameters.AddWithValue("@U_Password", userData.U_Password);
                    insertCmd.Parameters.AddWithValue("@U_RepeatPassword", userData.U_RepeatPassword);
                    insertCmd.Parameters.AddWithValue("@U_Type", userData.U_Type);

                    myCon.Open();
                    insertCmd.ExecuteNonQuery();
                }
                myCon.Close();
            }

            return Ok("User registered successfully");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Users usp)
        {
            string query = @"
        UPDATE Users 
        SET U_Name = @U_Name, 
            U_Surname = @U_Surname, 
            U_Email = @U_Email, 
            U_Username = @U_Username, 
            U_Phone = @U_Phone, 
            U_Password = @U_Password,
            U_RepeatPassword = @U_RepeatPassword,
            U_Type = @U_Type

        WHERE U_Id = @U_Id";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Id", id);
                    myCommand.Parameters.AddWithValue("@U_Name", usp.U_Name);
                    myCommand.Parameters.AddWithValue("@U_Surname", usp.U_Surname);
                    myCommand.Parameters.AddWithValue("@U_Email", usp.U_Email);
                    myCommand.Parameters.AddWithValue("@U_Username", usp.U_Username);
                    myCommand.Parameters.AddWithValue("@U_Phone", usp.U_Phone);
                    myCommand.Parameters.AddWithValue("@U_Password", usp.U_Password);
                    myCommand.Parameters.AddWithValue("@U_RepeatPassword", usp.U_RepeatPassword);
                    myCommand.Parameters.AddWithValue("@U_Type", usp.U_Type);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                DELETE FROM dbo.Users
                WHERE U_Id = @U_Id
            ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Id", id);
                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                }
                myCon.Close();
            }
            return Ok("User deleted successfully");
        }

        private const string SessionKeyName = "UserId";

        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            string query = @"SELECT U_Id, U_Email, U_Type FROM dbo.Users WHERE U_Email = @U_Email AND U_Password = @U_Password";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Email", login.U_Email);
                    myCommand.Parameters.AddWithValue("@U_Password", login.U_Password);

                    myCon.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string userType = reader.GetString(2);  

                        HttpContext.Session.SetInt32(SessionKeyName, userId);

                        return Ok(new { UserId = userId, U_Email = email, U_Type = userType });
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
