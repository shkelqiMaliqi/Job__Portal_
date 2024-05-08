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

    public class AdditionalSkillsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private object httpRequest;

        public AdditionalSkillsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }



        //CV AdditionalSkills Create
        [HttpPost]
        public IActionResult Post(AdditionalSkills cvAs)
        {
            string query = @"
                    INSERT INTO dbo.Cv_AdditionalSkills (CvAs_ASkills) 
                    VALUES (@CvAs_ASkills)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvAs_ASkills", cvAs.CvAs_ASkills);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV CvAdditionalSkills Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT CvAs_Id ,CvAs_ASkills FROM dbo.Cv_AdditionalSkills";

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

        //CV AdditionalSkills Update
        [HttpPut]
        public IActionResult Put(AdditionalSkills cvAs)
        {
            string query = @"
                    UPDATE dbo.Cv_AdditionalSkills
                    SET CvAs_ASkills=@CvAs_ASkills
                    where CvAs_Id=@CvAs_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvAs_Id", cvAs.CvAs_Id);
                    myCommand.Parameters.AddWithValue("@CvAs_ASkills", cvAs.CvAs_ASkills);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV AdditionalSkills Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCvAdditionalSkills(int id)
        {
            string query = @"
                    delete from dbo.Cv_AdditionalSkills
                    where CvAs_Id = @CvAs_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvAs_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }


    }
}