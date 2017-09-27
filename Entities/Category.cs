using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Category
    {
        public int id { get; set; }
        public String name { get; set; }

        public override string ToString()
        {
            return "id=" + id + " name=" + name;
        }
    }
}
