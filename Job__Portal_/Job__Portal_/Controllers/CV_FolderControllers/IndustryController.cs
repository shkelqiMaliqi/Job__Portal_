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

    public class IndustryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private object httpRequest;

        public IndustryController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpPost]
        public IActionResult Post(Industry cvInd)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Industry (CvIndustry_IndustryType) 
                    VALUES (@CvIndustry_IndustryType)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvIndustry_IndustryType", cvInd.CvIndustry_IndustryType);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Education Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT CvIndustry_Id ,CvIndustry_IndustryType FROM dbo.Cv_Industry";

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

        //CV Education Update
        [HttpPut]
        public IActionResult Put(Industry cvInd)
        {
            string query = @"
                    UPDATE dbo.Cv_Industry
                    SET CvIndustry_IndustryType=@CvIndustry_IndustryType
                    where CvIndustry_Id=@CvIndustry_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvIndustry_Id", cvInd.Cv_Industry_Id);
                    myCommand.Parameters.AddWithValue("@CvIndustry_IndustryType", cvInd.CvIndustry_IndustryType);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Education Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Cv_Industry
                    where CvIndustry_Id = @CvIndustry_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvIndustry_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

    }
}
