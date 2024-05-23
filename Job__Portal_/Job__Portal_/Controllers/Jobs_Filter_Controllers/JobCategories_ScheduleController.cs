using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models.Job_Filter;

namespace Job__Portal_.Controllers.Jobs_Filter
{
    [Route("api/[controller]")]
    [ApiController]

    public class JobCategories_ScheduleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public JobCategories_ScheduleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT JobCategories_ScheduleId ,JobCategories_Schedule_Time FROM dbo.JobCategories_Schedule";

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


        [HttpPost]
        public IActionResult Post(JobCategories_Schedule jobC_Sch)
        {
            string query = @"
                    INSERT INTO dbo.JobCategories_Schedule (JobCategories_Schedule_Time) 
                    VALUES (@JobCategories_Schedule_Time)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@JobCategories_Schedule_Time", jobC_Sch.JobCategories_Schedule_Time);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(JobCategories_Schedule jobC_Sch)
        {
            string query = @"
                    UPDATE dbo.JobCategories_Schedule
                    SET JobCategories_Schedule_Time=@JobCategories_Schedule_Time
                    where JobCategories_ScheduleId=@JobCategories_ScheduleId
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@JobCategories_ScheduleId", jobC_Sch.JobCategories_ScheduleId);
                    myCommand.Parameters.AddWithValue("@JobCategories_Schedule_Time", jobC_Sch.JobCategories_Schedule_Time);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    delete from dbo.JobCategories_Schedule
                    where JobCategories_ScheduleId = @JobCategories_ScheduleId
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@JobCategories_ScheduleId", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

    }
}