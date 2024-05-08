using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.CV_Folder
{
    public class Languages
    {
        [Key]
        public int CvLang_Id { get; set; }
        public string CvLang_Lang { get; set; }
    }
}
