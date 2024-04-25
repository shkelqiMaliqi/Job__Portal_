using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models
{
    public class UserType
    {

        /* Table 1-BussinesUser */
        [Key]
        public int B_Id { get; set; }
        public string B_CompanyName { get; set; }
        public string B_Email { get; set; }
        public int B_PhoneNumber { get; set; }
        public string B_Password { get; set; }
        public string B_RepeatPassword { get; set; }


        /*Table 2-UserType */
        [Key]
        public int UserType_Id { get; set; }
        public string UserType_Name { get; set; }


        /* Table 3-BusinessType */
        [Key]
        public int BusinessType_Id { get; set; }
        public string BusinessType_Name { get; set; }
    }
}
