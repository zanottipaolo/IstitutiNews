using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schools_identity.Model
{
    public class News
    {
        public string Title { set; get; }
        public string Link { set; get; }
        public DateTime PublishDate { set; get; }
        public string Description { set; get; }
        public string img { set; get; }
    }
}
