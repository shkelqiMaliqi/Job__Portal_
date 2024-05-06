using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models
{
    public class EnrollmentTypes
    {
        public int EnrollmentTypeId { get; set; }
        public string TypeName { get; set; }
    }

}
