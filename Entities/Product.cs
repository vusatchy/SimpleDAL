using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    class Product
    {
        public int id { get; set; }
        public String name { get; set; }
        public float price { get; set; }
        public bool isAvaliable { get; set; }
        public Category category { get; set; }

        public override string ToString()
        {
            return "id=" + id + " name=" + name + " price=" + price + " isAva=" + isAvaliable + " category=" + category;
        }
    }
}
