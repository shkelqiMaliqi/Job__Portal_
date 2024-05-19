using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Job__Portal_.Models.UserType
{
    public class BusinessType
    {
        /* Table 3-BusinessType */
       [Key]
       public int BusinessType_Id { get; set; }
       public string BusinessType_Name { get; set; } 
    }
}
