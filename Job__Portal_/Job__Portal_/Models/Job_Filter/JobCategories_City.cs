using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models.Job_Filter
{
    public class JobCategories_City

    {
        [Key]
        public int JobCategory_CityId { get; set; }

        public string JobCategory_City_Name { get; set; }

    }
}