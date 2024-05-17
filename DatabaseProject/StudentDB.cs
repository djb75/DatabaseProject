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

        public StudentDB(string PathStr)
        {
            pathStr = PathStr;
        }

        public List<string> GetUserNames()
        {
            var names = new List<string>();
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = pathStr;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "Select * from main.Student";
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var name = dataReader.GetString(0);
                    names.Add(name);
                }
            }
            return names;
        }

        public void AddUserName(int StudentID, string FirstName, string LastName, string DOB)
        {
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = pathStr;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "insert into main.Student (name) VALUES (@ID, @FirstName, @LastName, @DOB)";

                //Insert StudentID parameter
                var IDParameter = command.Parameters.Add("@ID", SqliteType.Integer);
                IDParameter.Value = StudentID;

                //Insert FirstName parameter
                var firstNameParameter = command.Parameters.Add("@FirstName", SqliteType.Text);
                firstNameParameter.Value = FirstName;


                command.ExecuteNonQuery();
            }
        }
    }
}
