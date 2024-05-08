using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Job__Portal_.Models.CV_Folder
{
    public class Education
    {
        [Key]
        public int CvEdu_Id { get; set; }
        public string CvEdu_Education { get; set; }

    }
}
