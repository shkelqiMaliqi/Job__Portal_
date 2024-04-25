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
    public class UserTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public UserTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //BusinessUser Create
        [HttpPost/*("BusinessUser")*/]
        public IActionResult Post/*BusinessUser*/(UserType usertype) 
        {
            string query = @"
                    INSERT INTO dbo.BusinessUser (B_CompanyName, B_Email, B_PhoneNumber, B_Password, B_RepeatPassword) 
                    VALUES (@B_CompanyName, @B_Email, @B_PhoneNumber, @B_Password, @B_RepeatPassword)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@B_CompanyName", usertype.B_CompanyName);
                    myCommand.Parameters.AddWithValue("@B_Email", usertype.B_Email);
                    myCommand.Parameters.AddWithValue("@B_PhoneNumber", usertype.B_PhoneNumber);
                    myCommand.Parameters.AddWithValue("@B_Password", usertype.B_Password);
                    myCommand.Parameters.AddWithValue("@B_RepeatPassword", usertype.B_RepeatPassword);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //Business Read
        [HttpGet/*("BusinessUser")*/]
        public JsonResult Get/*BusinessUser*/()
        {
            string query = @"SELECT B_Id, B_CompanyName, B_Email, B_PhoneNumber, B_Password, B_RepeatPassword  FROM dbo.BusinessUser";

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


        //Bussiness Update
        [HttpPut/*("BusinessUser")*/]
        public IActionResult Put/*BusinessUser*/(UserType usertype)
        { 
            string query = @"
                    UPDATE dbo.BusinessUser

                    SET

                    B_CompanyName = @B_CompanyName, 
                    B_Email = @B_Email,
                    B_PhoneNumber = @B_PhoneNumber,
                    B_Password = @B_Password,
                    B_RepeatPassword = @B_RepeatPassword,
                    
                    
                    where B_Id=@B_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@B_CompanyName", usertype.B_CompanyName);
                    myCommand.Parameters.AddWithValue("@B_Email", usertype.B_Email);
                    myCommand.Parameters.AddWithValue("@B_PhoneNumber", usertype.B_PhoneNumber);
                    myCommand.Parameters.AddWithValue("@B_Password", usertype.B_Password);
                    myCommand.Parameters.AddWithValue("@B_RepeatPassword", usertype.B_RepeatPassword);
                    myCommand.Parameters.AddWithValue("@B_Id",usertype.B_Id);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }



        //Business Delete
        [HttpDelete("{id}")]
        public IActionResult Delete/*BusinessUser*/(int id)
        {
            string query = @"
                    delete from dbo.BusinessUser
                    where B_Id = @B_Id
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
            return StatusCode(201);
        }


    }
}   



