using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Job__Portal_.Models;

namespace Job__Portal_.Models
{


        public class LoginModel
        {
            public string U_Email { get; set; }
            public string U_Password { get; set; }
        }
    }



