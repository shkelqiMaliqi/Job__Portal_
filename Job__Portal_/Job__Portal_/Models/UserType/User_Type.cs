using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.UserType
{
    public class User_Type
    {

       
        /*Table 2-UserType */
        [Key]
        public int UserType_Id { get; set; }
        public string UserType_Name { get; set; }


       
    }
}
