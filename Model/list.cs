using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace schools_identity.Model
{
    public class list
    {
        [Required]
        [Key]
        public long Id { set; get; }
        [Required]
        public string name { set; get;}
        [Required]
        public string city { set; get; }
        [Required]
        public string address { set; get; }
        [Required]
        public string headmaster { set; get; }
        [Required]
        public string courses { set; get; }
    }
}
