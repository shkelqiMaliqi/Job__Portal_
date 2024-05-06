using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Job__Portal_.Models.CV_Folder
{
    public class Courses
    {

        [Key]
        public int CvCourses_Id { get; set; }
        public string CvCourses_C { get; set; }

    }
}
