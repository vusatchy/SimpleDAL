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
    class FeedbackService : DBUtils, ITemplateDAL<Feedback>
    {
        public Feedback getById(int id)
        {
            Product product = new Product();
            User user = new User();
            Feedback feedback = new Feedback();
            Category category = new Category();
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT *, c.name AS cname FROM feedback f INNER JOIN user u ON f.user_id=u.id INNER JOIN product p ON f.id = p.id INNER JOIN category c ON p.category_id = c.id WHERE f.id=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();


                feedback.id = Int32.Parse(dataReader["id"].ToString());
                feedback.comment = dataReader["comment"].ToString();
                feedback.date = DateTime.Parse(dataReader["time"].ToString());

                user.id = Int32.Parse(dataReader["user_id"].ToString());
                user.login = dataReader["login"].ToString();
                user.password = dataReader["password"].ToString();
                user.sex = (Sex)Enum.Parse(typeof(Sex), dataReader["sex"].ToString().ToUpper());
                user.registrationTime = DateTime.Parse(dataReader["registration_time"].ToString());

                product.name = dataReader["name"].ToString();
                product.id = Int32.Parse(dataReader["product_id"].ToString());
                product.isAvaliable = Boolean.Parse(dataReader["is_avaliable"].ToString());
                product.price = float.Parse(dataReader["price"].ToString());

                category.id = Int32.Parse(dataReader["category_id"].ToString());
                category.name = dataReader["cname"].ToString();

                product.category = category;

                feedback.user = user;
                feedback.product = product;

                dataReader.Close();
            }
            return feedback;
        }

        public void add(Feedback f)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO feedback (user_id,product_id,comment,time) VALUES(@user_id,@product_id,@comment,@time)";
                command.Parameters.AddWithValue("@user_id", f.user.id);
                command.Parameters.AddWithValue("@product_id",f.product.id);
                command.Parameters.AddWithValue("@comment", f.comment);
                command.Parameters.AddWithValue("@time", f.date.ToString());
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void update(Feedback f)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE feedback set comment=@comment,time=@time WHERE user_id=@user_id AND product_id=@product_id";
                command.Parameters.AddWithValue("@user_id", f.user.id);
                command.Parameters.AddWithValue("@product_id", f.product.id);
                command.Parameters.AddWithValue("@comment", f.comment);
                command.Parameters.AddWithValue("@time", f.date.ToString());
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void delete(Feedback f)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE FROM feedback WHERE user_id=@user_id AND product_id=@product_id";
                command.Parameters.AddWithValue("@user_id", f.user.id);
                command.Parameters.AddWithValue("@product_id", f.product.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Feedback> getAll()
        {
            Product product = new Product();
            User user = new User();
            Feedback feedback = new Feedback();
            Category category = new Category();
            List<Feedback> feedbacks = new List<Feedback>();
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT *, c.name AS cname FROM feedback f INNER JOIN user u ON f.user_id=u.id INNER JOIN product p ON f.id = p.id INNER JOIN category c ON p.category_id = c.id";
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                     product = new Product();
                     user = new User();
                     feedback = new Feedback();
                     category = new Category();

                    feedback.id = Int32.Parse(dataReader["id"].ToString());
                    feedback.comment = dataReader["comment"].ToString();
                    feedback.date = DateTime.Parse(dataReader["time"].ToString());

                    user.id = Int32.Parse(dataReader["user_id"].ToString());
                    user.login = dataReader["login"].ToString();
                    user.password = dataReader["password"].ToString();
                    user.sex = (Sex)Enum.Parse(typeof(Sex), dataReader["sex"].ToString().ToUpper());
                    user.registrationTime = DateTime.Parse(dataReader["registration_time"].ToString());

                    product.name = dataReader["name"].ToString();
                    product.id = Int32.Parse(dataReader["product_id"].ToString());
                    product.isAvaliable = Boolean.Parse(dataReader["is_avaliable"].ToString());
                    product.price = float.Parse(dataReader["price"].ToString());

                    category.id = Int32.Parse(dataReader["category_id"].ToString());
                    category.name = dataReader["cname"].ToString();

                    product.category = category;

                    feedback.user = user;
                    feedback.product = product;

                    feedbacks.Add(feedback);
                }

                dataReader.Close();
            }
            return feedbacks;
        }
    }
    
}
