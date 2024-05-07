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

    public class CertificationsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private object httpRequest;

        public CertificationsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        //CV Certifications Create
        [HttpPost]
        public IActionResult Post(Certifications cvC)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Certifications (CvCertifications_Certifications) 
                    VALUES (@CvCertifications_Certifications)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvCertifications_Certifications", cvC.CvCertifications_Certifications);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Certifications Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT CvCertifications_Id ,CvCertifications_Certifications FROM dbo.Cv_Certifications";

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

        //CV Certifications Update
        [HttpPut]
        public IActionResult Put(Certifications cvC)
        {
            string query = @"
                    UPDATE dbo.Cv_Certifications
                    SET CvCertifications_Certifications=@CvCertifications_Certifications
                    where CvCertifications_Id=@CvCertifications_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvCertifications_Id", cvC.CvCertifications_Id);
                    myCommand.Parameters.AddWithValue("@CvCertifications_Certifications", cvC.CvCertifications_Certifications);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Certifications Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCvCertifications(int id)
        {
            string query = @"
                    delete from dbo.Cv_Certifications
                    where CvCertifications_Id = @CvCertifications_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvCertifications_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }




    }
}