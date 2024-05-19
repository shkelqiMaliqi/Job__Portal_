using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models
{
    public class Users

    {
        [Key]
        public int U_Id { get; set; }

        public string U_Name { get; set; }
        public string U_Surname { get; set; }

        public string U_Email { get; set; }
        public string U_Username { get; set; }
        public int U_Phone { get; set; }
        public string U_Password { get; set; }
        public string U_RepeatPassword { get; set; }
      

      
    }


}

