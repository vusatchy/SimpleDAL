using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Feedback
    {
        public int id { get; set; }
        public User user { get; set; }
        public Product product { get; set; }
        public String comment { get; set; }
        public DateTime date { get; set; }

        public override string ToString()
        {
            return "id=" + id + " user=" + user + " product=" + product + " comment=" + comment + " date=" + date;
        }
    }
}
