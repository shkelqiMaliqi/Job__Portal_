﻿using Microsoft.Extensions.Configuration;
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
 
        public class CvController : ControllerBase
        {
            private readonly IConfiguration _configuration;
            private readonly IWebHostEnvironment _env;
            private object httpRequest;

            public CvController(IConfiguration configuration, IWebHostEnvironment env)
            {
                _configuration = configuration;
                _env = env;
            }



        // CV Main Create
        [HttpPost]
        public IActionResult Post(Cv cv)
        {
            string query = @"
           INSERT INTO dbo.Cv
            (Cv_Name, Cv_Surame, Cv_DateOfBirth,
             Cv_PhoneNumber, Cv_Email) 

            VALUES 

            (@Cv_Name, @Cv_Surame, @Cv_DateOfBirth,
             @Cv_PhoneNumber, @Cv_Email)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@Cv_Name", cv.Cv_Name);
                    myCommand.Parameters.AddWithValue("@Cv_Surname", cv.Cv_Surname);
                    myCommand.Parameters.AddWithValue("@CV_DateOfBirth", cv.Cv_DateOfBirth);
                    myCommand.Parameters.AddWithValue("@Cv_PhoneNumber", cv.Cv_PhoneNumber);
                    myCommand.Parameters.AddWithValue("@Cv_Email", cv.Cv_Email);
                 
                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201); 
        }

        //CV Main Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            SELECT 
                   Cv_Id, Cv_Name, Cv_Surname, Cv_DateOfBirth,
                   Cv_PhoneNumber, Cv_Email

            FROM dbo.CV";

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

        //CV Main Update
        [HttpPut]
        public IActionResult Put(Cv cv)
        {
            string query = @"
                    UPDATE dbo.Cv

                    SET

                    Cv_Name = @Cv_Name, 
                    Cv_Surame = @Cv_Surname,
                    Cv_DateOfBirth = @Cv_DateOfBirth,
                    Cv_PhoneNumber = @Cv_PhoneNumber,
                    Cv_Email = @Cv_Email,
                    
                    
                    where Cv_Id=@Cv_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Cv_Id", cv.Cv_Id);
                    myCommand.Parameters.AddWithValue("@Cv_Name", cv.Cv_Name);
                    myCommand.Parameters.AddWithValue("@Cv_Surname", cv.Cv_Surname);
                    myCommand.Parameters.AddWithValue("@CV_DateOfBirth", cv.Cv_DateOfBirth);
                    myCommand.Parameters.AddWithValue("@Cv_PhoneNumber", cv.Cv_PhoneNumber);
                    myCommand.Parameters.AddWithValue("@Cv_Email", cv.Cv_Email);
                    

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Main Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Cv
                    where Cv_Id = @Cv_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Cv_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }


        //CV Education Create
        [HttpGet("CvEducation")]
        public JsonResult GetCvEducation()
        {
            string query = @"SELECT CvEdu_Id ,CvEdu_Education FROM dbo.Cv_Education";

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

        //CV Education Read
        [HttpPost("CvEducation")]
        public IActionResult PostCvEducation(Cv cvEdu)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Education (CvEdu_Education) 
                    VALUES (@CvEdu_Education)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvEdu_Education", cvEdu.CvEdu_Education);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Education Update
        [HttpPut("CvEducation")]
        public IActionResult PutCvEducation(Cv cvEdu)
        {
            string query = @"
                    UPDATE dbo.Cv_Education
                    SET CvEdu_Education=@CvEdu_Education
                    where CvEdu_Id=@CvEdu_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvEdu_Id", cvEdu.CvEdu_Id);
                    myCommand.Parameters.AddWithValue("@CvEdu_Education", cvEdu.CvEdu_Education);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Education Delete
        [HttpDelete("CvEducation/{id}")]
        public IActionResult DeleteCvEducation(int id)
        {
            string query = @"
                    delete from dbo.Cv_Education
                    where CvEdu_Id = @CvEdu_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvEdu_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }


        //CV Experience Create

        //CV Experience Read

        //CV Experience Update

        //CV Experience Delete
    }
}
