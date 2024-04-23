using Microsoft.AspNetCore.Http;
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
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Create
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT C_ID, C_Name, C_Surname, C_Email, C_Subject, C_Message, C_TimeCreated FROM dbo.Contact_Form";

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

        //Read 
        [HttpPost]
        public IActionResult Post(Contact c)
        {
            string query = @"
                    INSERT INTO dbo.Contact_Form (C_Name,C_Surname,C_Email,C_Subject,C_Message,C_TimeCreated) 
                    VALUES (@C_Name, @C_Surname, @C_Email, @C_Subject, @C_Message, @C_TimeCreated)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@C_Name", c.C_Name);
                    myCommand.Parameters.AddWithValue("@C_Surname", c.C_Surname);
                    myCommand.Parameters.AddWithValue("@C_Email", c.C_Email);
                    myCommand.Parameters.AddWithValue("@C_Subject", c.C_Subject);
                    myCommand.Parameters.AddWithValue("@C_Message", c.C_Message);
                    myCommand.Parameters.AddWithValue("@C_TimeCreated", c.C_TimeCreated);

                    myCon.Open();
                    myCommand.ExecuteNonQuery(); // Execute the query without a reader
                    myCon.Close();
                }
            }
            return StatusCode(201, "Contact information created successfully."); // Return status code for created resource
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact c)
        {
            string query = @"
            UPDATE dbo.Contact_Form SET 
            C_Name = @C_Name, 
            C_Surname = @C_Surname, 
            C_Email = @C_Email, 
            C_Subject = @C_Subject, 
            C_Message = @C_Message, 
            C_TimeCreated = @C_TimeCreated
            WHERE C_ID = @C_ID";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@C_ID", id);
                    myCommand.Parameters.AddWithValue("@C_Name", c.C_Name);
                    myCommand.Parameters.AddWithValue("@C_Surname", c.C_Surname);
                    myCommand.Parameters.AddWithValue("@C_Email", c.C_Email);
                    myCommand.Parameters.AddWithValue("@C_Subject", c.C_Subject);
                    myCommand.Parameters.AddWithValue("@C_Message", c.C_Message);
                    myCommand.Parameters.AddWithValue("@C_TimeCreated", c.C_TimeCreated);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("Contact information updated successfully.");
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"DELETE FROM dbo.Contact_Form WHERE C_ID = @C_ID";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@C_ID", id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return Ok("Contact information deleted successfully.");
        }


    }
}