using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models;

namespace Job__Portal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public JobsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // -------------------------- CREATE ------------------
        [HttpPost]
        public IActionResult Post([FromForm] Jobs job)
        {
            string query = @"
           INSERT INTO dbo.Jobs
           (JobTitle, NumberOfPositions, JobDescription,
           Qualification, Experience, Requirements,
           JobType, CompanyName, CompanyLogo, Website,
           CompanyEmail, CompanyAddress, CompanyCountry, CompanyState, CompanyPhone,
           CreateDate_C, JobCategoryId, JobCategories_ScheduleId, JobCategories_CityId, U_Id) 
     VALUES 
           (@JobTitle, @NumberOfPositions, @JobDescription,
            @Qualification, @Experience, @Requirements,
            @JobType, @CompanyName, @CompanyLogo, @Website,
            @CompanyEmail, @CompanyAddress, @CompanyCountry, @CompanyState, @CompanyPhone,
            @CreateDate_C, @JobCategoryId, @JobCategories_ScheduleId, @JobCategories_CityId, @U_Id)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    myCommand.Parameters.AddWithValue("@NumberOfPositions", job.NumberOfPositions);
                    myCommand.Parameters.AddWithValue("@JobDescription", job.JobDescription);
                    myCommand.Parameters.AddWithValue("@Qualification", job.Qualification);
                    myCommand.Parameters.AddWithValue("@Experience", job.Experience);
                    myCommand.Parameters.AddWithValue("@Requirements", job.Requirements);
                    myCommand.Parameters.AddWithValue("@JobType", job.JobType);
                    myCommand.Parameters.AddWithValue("@CompanyName", job.CompanyName);
                    myCommand.Parameters.AddWithValue("@CompanyLogo", job.CompanyLogo);
                    myCommand.Parameters.AddWithValue("@Website", job.Website);
                    myCommand.Parameters.AddWithValue("@CompanyEmail", job.CompanyEmail);
                    myCommand.Parameters.AddWithValue("@CompanyAddress", job.CompanyAddress);
                    myCommand.Parameters.AddWithValue("@CompanyCountry", job.CompanyCountry);
                    myCommand.Parameters.AddWithValue("@CompanyState", job.CompanyState);
                    myCommand.Parameters.AddWithValue("@CompanyPhone", job.CompanyPhone);
                    myCommand.Parameters.AddWithValue("@CreateDate_C", job.CreateDate_C);
                    myCommand.Parameters.AddWithValue("@JobCategoryId", job.JobCategoryId);
                    myCommand.Parameters.AddWithValue("@JobCategories_ScheduleId", job.JobCategories_ScheduleId);
                    myCommand.Parameters.AddWithValue("@JobCategories_CityId", job.JobCategories_CityId);
                    myCommand.Parameters.AddWithValue("@U_Id", job.U_Id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        // ------------------------------ READ --------------------------
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            SELECT 
                   JobId, JobTitle, NumberOfPositions, JobDescription,
                   Qualification, Experience, Requirements, 
                   JobType, CompanyName, CompanyLogo, Website,
                   CompanyEmail,CompanyAddress, CompanyCountry, CompanyState, CompanyPhone,
                   CreateDate_C, JobCategoryId, JobCategories_ScheduleId, JobCategories_CityId, U_Id

            FROM dbo.Jobs";

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

        // --------------- UPDATE --------------------------------
        [HttpPut]
        public IActionResult Put([FromForm] Jobs job)
        {
            string query = @"
                    UPDATE dbo.Jobs
                    SET
                    JobTitle = @JobTitle,                    
                    NumberOfPositions = @NumberOfPositions, 
                    JobDescription =  @JobDescription,
                    Qualification = @Qualification,
                    Experience = @Experience, 
                    Requirements = @Requirements, 
                    JobType = @JobType, 
                    CompanyName = @CompanyName, 
                    CompanyLogo = @CompanyLogo, 
                    Website = @Website,
                    CompanyEmail = @CompanyEmail, 
                    CompanyAddress = @CompanyAddress,
                    CompanyCountry = @CompanyCountry,     
                    CompanyState = @CompanyState, 
                    CompanyPhone = @CompanyPhone,
                    CreateDate_C = @CreateDate_C,
                    JobCategoryId = @JobCategoryId, 
                    JobCategories_ScheduleId = @JobCategories_ScheduleId, 
                    JobCategories_CityId = @JobCategories_CityId,
                    U_Id = @U_Id 
                    
                    WHERE JobId = @JobId
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@JobId", job.JobId);
                    myCommand.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    myCommand.Parameters.AddWithValue("@NumberOfPositions", job.NumberOfPositions);
                    myCommand.Parameters.AddWithValue("@JobDescription", job.JobDescription);
                    myCommand.Parameters.AddWithValue("@Qualification", job.Qualification);
                    myCommand.Parameters.AddWithValue("@Experience", job.Experience);
                    myCommand.Parameters.AddWithValue("@Requirements", job.Requirements);
                    myCommand.Parameters.AddWithValue("@JobType", job.JobType);
                    myCommand.Parameters.AddWithValue("@CompanyName", job.CompanyName);
                    myCommand.Parameters.AddWithValue("@CompanyLogo", job.CompanyLogo);
                    myCommand.Parameters.AddWithValue("@Website", job.Website);
                    myCommand.Parameters.AddWithValue("@CompanyEmail", job.CompanyEmail);
                    myCommand.Parameters.AddWithValue("@CompanyAddress", job.CompanyAddress);
                    myCommand.Parameters.AddWithValue("@CompanyCountry", job.CompanyCountry);
                    myCommand.Parameters.AddWithValue("@CompanyState", job.CompanyState);
                    myCommand.Parameters.AddWithValue("@CompanyPhone", job.CompanyPhone);
                    myCommand.Parameters.AddWithValue("@CreateDate_C", job.CreateDate_C);
                    myCommand.Parameters.AddWithValue("@JobCategoryId", job.JobCategoryId);
                    myCommand.Parameters.AddWithValue("@JobCategories_ScheduleId", job.JobCategories_ScheduleId);
                    myCommand.Parameters.AddWithValue("@JobCategories_CityId", job.JobCategories_CityId);
                    myCommand.Parameters.AddWithValue("@U_Id", job.U_Id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        // ---------------- DELETE --------------------------------
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    DELETE FROM dbo.Jobs
                    WHERE JobId = @JobId
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@JobId", id);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        // -------------------- Images --------------------------
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = Path.Combine(_env.ContentRootPath, "Photos", filename);

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception ex)
            {
                return new JsonResult("");
            }
        }
    }
}
