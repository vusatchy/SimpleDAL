using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using DAL;
using Entities;
using MySql.Data.MySqlClient;


namespace Services
{
    class ProductService : DBUtils,ITemplateDAL<Product>
    {
        public Product getById(int id)
        {
            return null;
        }
        public void add(Product f)
        {

        }
        public void update(Product obj)
        {
        }
        public void delete(Product obj)
        {
        }
        public List<Product> getAll()
        {
            return null;
        }
    }
}
