using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
       public string LastDateToApply { get; set; }
       public string JobType { get; set; }
       public string CompanyName { get; set; }
       public string CompanyLogo { get; set; }
       public string Website { get; set; }
       public string CompanyEmail { get; set; }
       public string CompanyAddress { get; set; }
       public string CompanyCountry { get; set; }
       public string CompanyState { get; set; }
       public int CompanyPhone { get; set; }
       public DateTime CreateDate_C { get; set; }

    }
}
