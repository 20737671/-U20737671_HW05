using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;






namespace Homework_05.Models
{
    public class Books
    {
        [DisplayName("#")]
        public int BookID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        
        [DisplayName("Points")]
        public int Point { get; set; }

        
        [DisplayName("Author")]
        public int AuthorID { get; set; }

        
        [DisplayName("Type")]
        public int TypeID { get; set; }

       
        [DisplayName("Page Count")]
        public int Pagecount { get; set; }

        public string title { get; set; }

    }
}