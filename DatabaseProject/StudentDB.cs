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

        public void AddStudentRecord(string[] parameters)
        {
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = pathStr;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "insert into main.Student VALUES (@ID, @FirstName, @LastName, @DOB)";

                //Insert StudentID parameter
                var IDParameter = command.Parameters.Add("@ID", SqliteType.Integer);
                IDParameter.Value = Int32.Parse(parameters[0]);    //Convert to an integer

                //Insert FirstName parameter
                var firstNameParameter = command.Parameters.Add("@FirstName", SqliteType.Text);
                firstNameParameter.Value = parameters[1];

                //Insert LastName parameter
                var lastNameParameter = command.Parameters.Add("@LastName", SqliteType.Text);
                lastNameParameter.Value = parameters[2];

                //Insert DOB parameter
                var DOBParameter = command.Parameters.Add("@DOB", SqliteType.Text);
                DOBParameter.Value = parameters[3];

                command.ExecuteNonQuery();
            }
        }
    }
}
