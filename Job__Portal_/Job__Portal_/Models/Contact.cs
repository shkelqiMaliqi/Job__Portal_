using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Job__Portal_.Models
{
    public class Contact_Form

    {
        public int Contact_Id { get; set; }

        public string Contact_Name { get; set; }
        public string Contact_Surame { get; set; }

        public string Contact_Email { get; set; }
        public string Contact_Subject { get; set; }
        public string Contact_Message { get; set; }
        public DateTime Contact_TimeCreated { get; set; }


    }
}
