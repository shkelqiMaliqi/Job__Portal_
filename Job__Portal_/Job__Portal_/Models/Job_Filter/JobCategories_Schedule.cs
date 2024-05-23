using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models.Job_Filter
{
    public class JobCategories_Schedule

    {
        [Key]
        public int JobCategories_ScheduleId { get; set; }

        public string JobCategories_Schedule_Time { get; set; }

    }
}