using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Job__Portal_.Models.CV_Folder
{
    public class AddMore
    {


        [Key]
        public int CvAddMore_Id { get; set; }
        public string CvAddMore_Add { get; set; }

    }
}
