using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Utils
{
    class DBUtils
    {
        private const String DB_CONNECT="Database=registered_user;Data Source=localhost;User Id=root;Password=root";
        private  static MySqlConnection connection=new MySqlConnection(DB_CONNECT);

        protected static MySqlConnection getConnection(){
            return connection;
        }
    }
}
