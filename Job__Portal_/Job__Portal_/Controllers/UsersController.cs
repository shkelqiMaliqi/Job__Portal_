using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private SqlDataReader myReader;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT U_ID, U_Name, U_Surname, U_Email, U_Username, U_Phone, U_Password, U_RepeatPassword FROM dbo.Users";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
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
                    myCon.Close();
                }
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

        [HttpPost]
        public IActionResult Post(Users usp)
        {
            string query = @"
                    INSERT INTO dbo.Users (U_Name,U_Surname,U_Email,U_Username,U_Phone,U_Password,U_RepeatPassword) 
                    VALUES (@U_Name, @U_Surname, @U_Email, @U_Username, @U_Phone, @U_Password, @U_RepeatPassword)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Name", usp.U_Name);
                    myCommand.Parameters.AddWithValue("@U_Surname", usp.U_Surname);
                    myCommand.Parameters.AddWithValue("@U_Email", usp.U_Email);
                    myCommand.Parameters.AddWithValue("@U_Username", usp.U_Username);
                    myCommand.Parameters.AddWithValue("@U_Phone", usp.U_Phone);
                    myCommand.Parameters.AddWithValue("@U_Password", usp.U_Password);
                    myCommand.Parameters.AddWithValue("@U_RepeatPassword", usp.U_RepeatPassword);
                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("User added successfully");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Users usp)
        {
            string query = @"
            UPDATE dbo.Users 
            SET U_Name = @U_Name, 
                U_Surname = @U_Surname, 
                U_Email = @U_Email, 
                U_Username = @U_Username, 
                U_Phone = @U_Phone, 
                U_Password = @U_Password, 
                U_RepeatPassword = @U_RepeatPassword 
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
                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("User updated successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Users
                    where U_Id = @U_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return new JsonResult("User Deleted Succesfully");
        }




    private const string SessionKeyName = "UserId";

    [HttpPost("login")]
    public IActionResult Login(LoginModel login)
    {
        string query = @"SELECT U_Id, U_Email FROM dbo.Users WHERE U_Email = @U_Email AND U_Password = @U_Password";

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

                    // Store user ID in session
                    HttpContext.Session.SetInt32(SessionKeyName, userId);

                    return Ok(new { UserId = userId, U_Email = email });
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
        // Remove user ID from session
        HttpContext.Session.Remove(SessionKeyName);

        return Ok("Logged out successfully");
    }

    
    }   
}

    

         

