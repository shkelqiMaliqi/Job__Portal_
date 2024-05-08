using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.CV_Folder
{
    public class Industry
    {
        [Key]
        public int Cv_Industry_Id { get; set; }
        public string Cv_Industry_IndustryType { get; set; }

    }
}
