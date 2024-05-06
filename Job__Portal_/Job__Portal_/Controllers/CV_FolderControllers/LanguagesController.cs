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

    public class LanguagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private object httpRequest;

        public LanguagesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }



        //CV Languages Create
        [HttpPost]
        public IActionResult Post(Languages cvL)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Languages (CvLang_Lang) 
                    VALUES (@CvLang_Lang)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvLang_Lang", cvL.CvLang_Lang);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Languages Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT CvLang_Id ,CvLang_Lang FROM dbo.Cv_Languages";

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

        //CV Languages Update
        [HttpPut]
        public IActionResult Put(Languages cvL)
        {
            string query = @"
                    UPDATE dbo.Cv_Languages
                    SET CvLang_Lang=@CvLang_Lang
                    where CvLang_Id=@CvLang_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvLang_Id", cvL.CvLang_Id);
                    myCommand.Parameters.AddWithValue("@CvLang_Lang", cvL.CvLang_Lang);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Languages Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCvLanguages(int id)
        {
            string query = @"
                    delete from dbo.Cv_Languages
                    where CvLang_Id = @CvLang_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvLang_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }


    }
}