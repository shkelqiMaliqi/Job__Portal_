﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models
{
    public class JobCategories

    {
        [Key]
        public int JobCategoryID { get; set; }

        public string JobCategoryName { get; set; }

    }
}