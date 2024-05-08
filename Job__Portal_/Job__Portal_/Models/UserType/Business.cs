using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.UserType
{
    public class Business
    {
       
       [Key]
       public int B_Id { get; set; }
       public string B_CompanyName { get; set; }
       public string B_Email { get; set; }
       public int B_PhoneNumber { get; set; }
       public string B_Password { get; set; }
       public string B_RepeatPassword { get; set; }
       

    }
}
