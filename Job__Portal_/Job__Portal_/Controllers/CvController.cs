using Microsoft.Extensions.Configuration;
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

        //CV Education Read
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
        [HttpPost("CvExperience")]
        public IActionResult PostCvExperience(Cv cvExp)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Experience (CvExp_Experiences) 
                    VALUES (@CvExp_Experiences)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvExp_Experiences", cvExp.CvExp_Experiences);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Education Read
        [HttpGet("CvExperience")]
        public JsonResult GetCvExperience()
        {
            string query = @"SELECT CvExp_Id ,CvExp_Experiences FROM dbo.Cv_Experience";

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
        [HttpPut("CvExperirence")]
        public IActionResult PutCvExperience(Cv cvExp)
        {
            string query = @"
                    UPDATE dbo.Cv_Experiences
                    SET CvExp_Experiences=@CvExp_Experiences
                    where CvExp_Id=@CvExp_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvExp_Id", cvExp.CvExp_Id);
                    myCommand.Parameters.AddWithValue("@CvExp_Experiences", cvExp.CvExp_Experiences);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Education Delete
        [HttpDelete("CvExperience/{id}")]
        public IActionResult DeleteCvExperience(int id)
        {
            string query = @"
                    delete from dbo.Cv_Experience
                    where CvExp_Id = @CvExp_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvExp_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }



        //CV Experience Create
        [HttpPost("CvIndustry")]
        public IActionResult PostCvIndustry(Cv cvInd)
        {
            string query = @"
                    INSERT INTO dbo.Cv_Industry (Cv_Industry_IndustryType) 
                    VALUES (@Cv_Industry_IndustryType)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Cv_Industry_IndustryType", cvInd.Cv_Industry_IndustryType);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV Education Read
        [HttpGet("CvIndustry")]
        public JsonResult GetIndustry()
        {
            string query = @"SELECT CvIndustry_Id ,Cv_Industry_IndustryType FROM dbo.Cv_Industry";

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
        [HttpPut("CvIndustry")]
        public IActionResult PutCvIndustry(Cv cvInd)
        {
            string query = @"
                    UPDATE dbo.Cv_Industry
                    SET Cv_Industry_IndustryType=@Cv_Industry_IndustryType
                    where CvIndustry_Id=@CvIndustry_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvIndustry_Id", cvInd.Cv_Industry_Id);
                    myCommand.Parameters.AddWithValue("@Cv_Industry_IndustryType", cvInd.Cv_Industry_IndustryType);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV Education Delete
        [HttpDelete("CvIndustry/{id}")]
        public IActionResult DeleteCvIndustry(int id)
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



        //CV TechnicalSkills Create
        [HttpPost("CvTechnicalSkills")]
        public IActionResult PostCvTechnicalSkills(Cv cvTs)
        {
            string query = @"
                    INSERT INTO dbo.Cv_TechnicalSkills (CvTs_TSkills) 
                    VALUES (@CvTs_TSkills)";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvTs_TSkills", cvTs.CvTs_TSkills);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }

        //CV TechnicalSkills Read
        [HttpGet("CvTechnicalSkills")]
        public JsonResult GetCvTechnicalSkills()
        {
            string query = @"SELECT CvTs_Id ,CvTs_TSkills FROM dbo.Cv_TechnicalSkills";

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

        //CV TechnicalSkills Update
        [HttpPut("CvTechnicalSkills")]
        public IActionResult PutCvTechnicalSkills(Cv cvTs)
        {
            string query = @"
                    UPDATE dbo.Cv_TechnicalSkills
                    SET CvTs_TSkills=@CvTs_TSkills
                    where CvTs_Id=@CvTs_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvTs_Id", cvTs.Cv_Industry_Id);
                    myCommand.Parameters.AddWithValue("@CvTs_TSkills", cvTs.CvTs_TSkills);


                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }
        //CV TechnicalSkills Delete
        [HttpDelete("CvTechnicalSkills/{id}")]
        public IActionResult DeleteCvTechnicalSkills(int id)
        {
            string query = @"
                    delete from dbo.Cv_TechnicalSkills
                    where CvTs_Id = @CvTs_Id
                    ";

            string sqlDataSource = _configuration.GetConnectionString("CRUDCS");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CvTs_Id", id);



                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return StatusCode(201);
        }





        //CV Certifications Create
        [HttpPost("CvCertifications")]
        public IActionResult PostCvCertifications(Cv cvC)
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
        [HttpGet("CvCertifications")]
        public JsonResult GetCvCertifications()
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
        [HttpPut("CvCertifications")]
        public IActionResult PutCvCertifications(Cv cvC)
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
        [HttpDelete("CvCertifications/{id}")]
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





        //CV AdditionalSkills Create
        [HttpPost("CvAdditionalSkills")]
        public IActionResult PostCvAdditionalSkills(Cv cvAs)
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
        [HttpGet("CvAdditionalSkills")]
        public JsonResult GetCv_AdditionalSkills()
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
        [HttpPut("CvAdditionalSkills")]
        public IActionResult PutCvAdditionalSkills(Cv cvAs)
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
        [HttpDelete("CvAdditionalSkills/{id}")]
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





        //CV Courses Create
        [HttpPost("CvCourses")]
        public IActionResult PostCvCourses(Cv cvCo)
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
        [HttpGet("CvCourses")]
        public JsonResult GetCvCourses()
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
        [HttpPut("CvCourses")]
        public IActionResult PutCvCourses(Cv cvCo)
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
        [HttpDelete("CvCourses/{id}")]
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





        //CV Languages Create
        [HttpPost("CvLanguages")]
        public IActionResult PostCvLanguages(Cv cvL)
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
        [HttpGet("CvLanguages")]
        public JsonResult GetCvLanguages()
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
        [HttpPut("CvLanguages")]
        public IActionResult PutCvLanguages(Cv cvL)
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
        [HttpDelete("CvLanguages/{id}")]
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





        //CV AddMore Create
        [HttpPost("CvAddMore")]
        public IActionResult PostCvAddMore(Cv cvAm)
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
        [HttpGet("CvAddMore")]
        public JsonResult GetCCvAddMore()
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
        [HttpPut("CvAddMore")]
        public IActionResult PutCvAddMore(Cv cvAm)
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
        [HttpDelete("CvAddMore/{id}")]
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
