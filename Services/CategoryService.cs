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
    class CategoryService : DBUtils, ITemplateDAL<Category>
    {
        public Category getById(int id)
        {
            Category category = new Category();
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM category WHERE user.id=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                category.id = Int32.Parse(dataReader["id"].ToString());
                category.name = dataReader["name"].ToString();
                dataReader.Close();
            }
            return category;
        }

        public void add(Category obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO category (id,name) VALUES(@id,@name)";
                command.Parameters.AddWithValue("@id", obj.id);
                command.Parameters.AddWithValue("@name", obj.name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void update(Category obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE category SET name=@name WHERE id=@id";
                command.Parameters.AddWithValue("@id", obj.id);
                command.Parameters.AddWithValue("@name", obj.name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void delete(Category obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM category WHERE id = @id";
                command.Parameters.AddWithValue("@id", obj.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Category> getAll()
        {
            List<Category> categories = new List<Category>();
            Category category = null;
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM category";
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    category = new Category();
                    category.id = Int32.Parse(dataReader["id"].ToString());
                    category.name = dataReader["name"].ToString();
                    categories.Add(category);
                }
                dataReader.Close();
            }
            return categories;
        }
    }
}
