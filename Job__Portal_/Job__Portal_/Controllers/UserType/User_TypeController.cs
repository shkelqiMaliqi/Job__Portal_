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
    public class User_TypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public User_TypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //UserType Create
        [HttpPost]
        public IActionResult Post(User_Type usert)
        {
            string query = @"
                    INSERT INTO dbo.UserType (UserType_Name) 
                    VALUES (@UserType_Name)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserType_Name", usert.UserType_Name);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }


        //UserType Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT UserType_Id, UserType_Name FROM dbo.UserType";

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

        //UserType Update
        [HttpPut]
        public IActionResult Put(User_Type usert)
        {
            string query = @"
                    UPDATE dbo.UserType

                    SET

                    UserType_Name = @UserType_Name
                    
                    
                    where UserType_Id=@UserType_Id
                    "
            ;

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserType_Name", usert.UserType_Name);
                    myCommand.Parameters.AddWithValue("@UserType_Id", usert.UserType_Id);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }



        //UserType Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    delete from dbo.UserType
                    where UserType_Id = @UserType_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserType_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

    }
}