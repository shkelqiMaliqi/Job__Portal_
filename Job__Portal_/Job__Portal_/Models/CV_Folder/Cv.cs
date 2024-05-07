using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.CV_Folder
{
    public class Cv
    {

        /* Table 1 */
        [Key]
        public int Cv_Id { get; set; }
        public string Cv_Name { get; set; }
        public string Cv_Surname { get; set; }
        public string Cv_DateOfBirth { get; set; }
        public string Cv_PhoneNumber { get; set; }
        public string Cv_Email { get; set; }

    }
}


