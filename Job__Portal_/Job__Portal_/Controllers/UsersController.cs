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
            string query = @"SELECT U_ID, U_Name, U_Surname, U_Email, U_Username, U_Phone, U_Password, U_RepeatPassword, U_TimeCreated FROM dbo.Users";

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

        [HttpPost]
        public IActionResult Post(Users usp)
        {
            string query = @"
                    INSERT INTO dbo.Users (U_Name,U_Surname,U_Email,U_Username,U_Phone,U_Password,U_RepeatPassword,U_TimeCreated) 
                    VALUES (@U_Name, @U_Surname, @U_Email, @U_Username, @U_Phone, @U_Password, @U_RepeatPassword, @U_TimeCreated)";

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
                    myCommand.Parameters.AddWithValue("@U_TimeCreated", usp.U_TimeCreated);

                    myCon.Open();
                    myCommand.ExecuteNonQuery(); // Execute the query without a reader
                    myCon.Close();
                }
            }
            return StatusCode(201); // Return status code for created resource
        }
        [HttpPut]
        public IActionResult Put(Users usp)
        {
            string query = @"
                    UPDATE dbo.Users 
                    SET U_Name = @U_Name, 
                        U_Surname = @U_Surname, 
                        U_Email = @U_Email, 
                        U_Username = @U_Username, 
                        U_Phone = @U_Phone, 
                        U_Password = @U_Password, 
                        U_RepeatPassword = @U_RepeatPassword, 
                        U_TimeCreated = @U_TimeCreated
                    WHERE U_Id = @U_Id";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@U_Id", usp.U_Id);
                    myCommand.Parameters.AddWithValue("@U_Name", usp.U_Name);
                    myCommand.Parameters.AddWithValue("@U_Surname", usp.U_Surname);
                    myCommand.Parameters.AddWithValue("@U_Email", usp.U_Email);
                    myCommand.Parameters.AddWithValue("@U_Username", usp.U_Username);
                    myCommand.Parameters.AddWithValue("@U_Phone", usp.U_Phone);
                    myCommand.Parameters.AddWithValue("@U_Password", usp.U_Password);
                    myCommand.Parameters.AddWithValue("@U_RepeatPassword", usp.U_RepeatPassword);
                    myCommand.Parameters.AddWithValue("@U_TimeCreated", usp.U_TimeCreated);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return new JsonResult("User updated Sucessfully");
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
    }

}

