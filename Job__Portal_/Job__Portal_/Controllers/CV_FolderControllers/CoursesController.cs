using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models.CV_Folder;

namespace Job__Portal_.Controllers.CV_FolderControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoursesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private object httpRequest;

        public CoursesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }



        [HttpPost]
        public IActionResult Post(Courses cvCo)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Courses (CvCourses_C) 
                    VALUES (@CvCourses_C)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvCourses_C", cvCo.CvCourses_C);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Courses Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT CvCourses_Id ,CvCourses_C FROM dbo.Cv_Courses";

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

        //CV Courses Update
        [HttpPut]
        public IActionResult Put(Courses cvCo)
        {
            string query = @"
                    UPDATE dbo.Cv_Courses
                    SET CvCourses_C=@CvCourses_C
                    where CvCourses_Id=@CvCourses_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvCourses_Id", cvCo.CvCourses_Id);
                    myCommand.Parameters.AddWithValue("@CvCourses_C", cvCo.CvCourses_C);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Courses Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCvCourses(int id)
        {
            string query = @"
                    delete from dbo.Cv_Courses
                    where CvCourses_Id = @CvCourses_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvCourses_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }


    }
}

