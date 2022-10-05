using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Homework_05.Models
{
    public class Types
    {

        public int TypeID { get; set; }


        [DisplayName("Type")]
        public string Name { get; set; }

    }
}