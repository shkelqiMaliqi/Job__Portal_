using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.Courses
{
    public class CoursesApply

    {
        [Key]
        public int CourseApplyId { get; set; }


        public string Attendant_Name { get; set; }

        public string Attendant_Surname { get; set; }

        public string Attendant_Email { get; set; }

        public int Attendant_PhoneNo { get; set; }

        public string Courses_ApplyingName { get; set; }

    }
}
