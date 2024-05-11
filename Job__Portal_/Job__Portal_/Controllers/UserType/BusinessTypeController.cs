using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Job__Portal_.Models.UserType;

namespace Job__Portal_.Controllers.UserType
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTypeController : ControllerBase
    {
       private readonly IConfiguration _configuration;
       private SqlDataReader myReader;

       public BusinessTypeController(IConfiguration configuration)
       {
            _configuration = configuration;
       }

        //BusinessType Create
        [HttpPost]
        public IActionResult Post(BusinessType businesst)
        {
            string query = @"
                    INSERT INTO dbo.BusinessType (BusinessType_Name) 
                    VALUES (@BusinessType_Name)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@BusinessType_Name", businesst.BusinessType_Name);

                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //BusinessType Read
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT BusinessType_Id, BusinessType_Name FROM dbo.BusinessType";

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


        //BusinessType Update
        [HttpPut]
        public IActionResult Put(BusinessType businesst)
        {
            string query = @"
                    UPDATE dbo.BusinessType

                    SET

                    BusinessType_Name = @BusinessType_Name
                    
                    
                    where BusinessType_Id=@BusinessType_Id
                    "
            ;

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@BusinessType_Name", businesst.BusinessType_Name);
                    myCommand.Parameters.AddWithValue("@BusinessType_Id", businesst.BusinessType_Id);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //BusinessType Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string query = @"
                    delete from dbo.BusinessType
                    where BusinessType_Id = @BusinessType_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserType_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

    }
}
