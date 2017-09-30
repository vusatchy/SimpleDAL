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
            Product product = new Product();
            Category category = new Category();
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT *,c.name as cname FROM product p INNER JOIN category c ON p.category_id=c.id WHERE p.id=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                product.name = dataReader["name"].ToString();
                product.id = Int32.Parse(dataReader["id"].ToString());
                product.isAvaliable = Boolean.Parse(dataReader["is_avaliable"].ToString());
                product.price = float.Parse(dataReader["price"].ToString());

                category.id = Int32.Parse(dataReader["category_id"].ToString());
                category.name = dataReader["cname"].ToString();
                product.category = category;
                dataReader.Close();
            }
            return product;
        }

        public void add(Product obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO product (id,name,price,is_avaliable,category_id) VALUES(@id,@name,@price,@is_avaliable,@category_id)";
                command.Parameters.AddWithValue("@id", obj.id);
                command.Parameters.AddWithValue("@name", obj.name);
                command.Parameters.AddWithValue("@price", obj.price);
                command.Parameters.AddWithValue("@is_avaliable", obj.isAvaliable);
                command.Parameters.AddWithValue("@category_id", obj.category.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void update(Product obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE user SET name=@name,price=@price,is_avaliable=@is_avaliable,category_id=@category_id WHERE id=@id";
                command.Parameters.AddWithValue("@id", obj.id);
                command.Parameters.AddWithValue("@name", obj.name);
                command.Parameters.AddWithValue("@price", obj.price);
                command.Parameters.AddWithValue("@is_avaliable", obj.isAvaliable);
                command.Parameters.AddWithValue("@category_id", obj.category.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void delete(Product obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM product WHERE id=@id";
                command.Parameters.AddWithValue("@id", obj.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Product> getAll()
        {
            List<Product> products = new List<Product>();
            Product product;
            Category category;
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT *,c.name as cname FROM product p INNER JOIN category c ON p.category_id=c.id";
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    product = new Product();
                    category = new Category();
                    product.name = dataReader["name"].ToString();
                    product.id = Int32.Parse(dataReader["id"].ToString());
                    product.isAvaliable = Boolean.Parse(dataReader["is_avaliable"].ToString());
                    product.price = float.Parse(dataReader["price"].ToString());

                    category.id = Int32.Parse(dataReader["category_id"].ToString());
                    category.name = dataReader["cname"].ToString();

                    product.category = category;
                    products.Add(product);
                }
                dataReader.Close();
            }
            return products;
        }
    }
}
