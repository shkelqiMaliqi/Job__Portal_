using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models.CV_Folder
{
    public class Certifications
    {
        /* Table 5 */
        [Key]
        public int CvCertifications_Id { get; set; }
        public string CvCertifications_Certifications { get; set; }

    }
}
