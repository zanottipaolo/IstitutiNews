using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace schools_identity.Model
{
    public class list
    {
        [Key]
        public long Id { set; get; }
        public string name { set; get;}
        public string city { set; get; }
        public string address { set; get; }
        public string headmaster { set; get; }
        public string courses { set; get; }
    }
}
