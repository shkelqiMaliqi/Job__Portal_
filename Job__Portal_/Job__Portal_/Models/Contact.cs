using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models
{
    public class Contact

    {
        public int C_Id { get; set; }

        public string C_Name { get; set; }
        public string C_Surname { get; set; }

        public string C_Email { get; set; }
        public string C_Subject { get; set; }
        public string C_Message { get; set; }
        


    }
}
