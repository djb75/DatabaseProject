using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DatabaseProject
{
    public class StudentDB
    {
        private string pathStr;

        public StudentDB(string pathStr)
        {
            pathStr = pathStr;
        }

        public List<string> GetUserNames()
        {
            var names = new List<string>();
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = pathStr;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "Select name from main.users";
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var name = dataReader.GetString(0);
                    names.Add(name);
                }
            }
            return names;
        }

        public void AddUserName(string userName)
        {
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = pathStr;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "insert into main.users (name) VALUES (@Name)";
                var nameParameter = command.Parameters.Add("@Name", SqliteType.Text);
                nameParameter.Value = userName;
                command.ExecuteNonQuery();
            }
        }
    }
}
