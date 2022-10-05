using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Homework_05.Models
{
    public class Authors
    {
        public int AuthorID { get; set; }

        public string Name { get; set; }


        [DisplayName("Author")]
        public string Surname { get; set; }

        public string Auth { get; set; }

    }
}