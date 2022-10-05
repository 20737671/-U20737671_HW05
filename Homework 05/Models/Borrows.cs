using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_05.Models
{
    public class Borrows
    {
        [DisplayName("#")]
        public int BorrowID { get; set; }

        public int StudentID { get; set; }

        public int BookID { get; set; }

        [DisplayName("Taken Date")]
        public DateTime TakenDate { get; set; }

        [DisplayName("Brought Date")]
        public DateTime BroughtDate { get; set; }


    }
}