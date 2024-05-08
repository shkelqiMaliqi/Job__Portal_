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

    public class AddMoreController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private object httpRequest;

        public AddMoreController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }



        //CV AddMore Create
        [HttpPost]
        public IActionResult Post(AddMore cvAm)
        {
            string query = @"
                    INSERT INTO dbo.Cv_AddMore (CvAddMore_Add) 
                    VALUES (@CvAddMore_Add)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvAddMore_Add", cvAm.CvAddMore_Add);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV AddMore Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT CvAddMore_Id ,CvAddMore_Add FROM dbo.Cv_AddMore";

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

        //CV AddMore Update
        [HttpPut]
        public IActionResult Put(AddMore cvAm)
        {
            string query = @"
                    UPDATE dbo.Cv_AddMore
                    SET CvAddMore_Add=@CvAddMore_Add
                    where CvAddMore_Id=@CvAddMore_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvAddMore_Id", cvAm.CvAddMore_Id);
                    myCommand.Parameters.AddWithValue("@CvAddMore_Add", cvAm.CvAddMore_Add);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV AddMore Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCvAddMore(int id)
        {
            string query = @"
                    delete from dbo.Cv_AddMore
                    where CvAddMore_Id = @CvAddMore_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvAddMore_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
    }
}