using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models
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

        /* Table 2 */
        [Key]
        public int CvExp_Id { get; set; }
        public string CvExp_Experinces { get; set; }

        /* Table 3 */
        [Key]
        public int Cv_Industry_Id { get; set; }
        public string Cv_Industry_IndustryType { get; set; }

        /* Table 4 */
        [Key]
        public int CvEdu_Id { get; set; }
        public string CvEdu_Education { get; set; }

        /* Table 5 */
        [Key]
        public int CvTs_Id { get; set; }
        public string CvTs_TSkills { get; set; }

        /* Table 5 */
        [Key]
        public int CvCertifications_Id { get; set; }
        public string CvCertifications_Certifications { get; set; }

        /* Table 7 */
        [Key]
        public int CvAs_Id { get; set; }
        public string CvAs_ASkills { get; set; }

        /* Table 8 */
        [Key]
        public int CvCourses_Id { get; set; }
        public string CvCourses_C { get; set; }

        /* Table 9 */
        [Key]
        public int CvLang_Id { get; set; }
        public string CvLang_Lang { get; set; }

        /* Table 10 */
        [Key]
        public int CvAddMore_Id { get; set; }
        public string CvAddMore_Add { get; set; }

    }
}


