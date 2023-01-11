using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDAL.Entities
{
    public class Subject
    {
        public int id { get; set; }
        public string subject_code { get; set; }
        public string subject_name { get; set; }
        public int credit { get; set; }
    }
}
