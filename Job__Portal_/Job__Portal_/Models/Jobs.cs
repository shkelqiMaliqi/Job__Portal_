using System;
using System.ComponentModel.DataAnnotations;

namespace Job__Portal_.Models
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int NumberOfPositions { get; set; }
        public string JobDescription { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Requirements { get; set; }
        public string JobType { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string Website { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyState { get; set; }
        public string CompanyPhone { get; set; }
        public DateTime CreateDate_C { get; set; }

        public int JobCategoryId { get; set; }
        public int JobCategories_ScheduleId { get; set; }
        public int JobCategories_CityId { get; set; }
        public int U_Id { get; set; }
    }
}
