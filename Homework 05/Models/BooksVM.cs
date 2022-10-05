using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_05.Models
{
    public class BooksVM
    {
        public Books book { get; set; }

        public Authors author { get; set; }

        public Types type { get; set; }

        public Borrows borrowing { get; set; }

        
    }
}