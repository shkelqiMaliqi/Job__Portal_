using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models.UserType;

namespace Job__Portal_.Controllers.UserType
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public BusinessController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //BusinessUser Create
        [HttpPost]
        public IActionResult Post(Business b)
        {
            string query = @"
                    INSERT INTO dbo.BusinessUser (B_CompanyName, B_Email, B_PhoneNumber, B_Password, B_RepeatPassword)
                    VALUES (@B_CompanyName, @B_Email, @B_PhoneNumber, @B_Password, @B_RepeatPassword)"
            ;

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


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //Business Read
        [HttpGet]
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
        [HttpPut]
        public IActionResult Put/*BusinessUser*/(Business b)
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
                    "
            ;

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
                    myCommand.Parameters.AddWithValue("@B_Id", b.B_Id);


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
