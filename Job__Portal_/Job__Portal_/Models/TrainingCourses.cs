using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models
{
    public class TrainingCourse
    {
        public int TrainingCourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Instructor { get; set; }
        public decimal Price { get; set; }
    }

}

