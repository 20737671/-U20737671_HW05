using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Homework_05.Models
{
    public class Students
    {
        [DisplayName("#")]
        public int StudentID { get; set; }


        [DisplayName("Borrowed By")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string Class { get; set; }
        [DisplayName("Points")]
        public int Point { get; set; }

    }
}