//using DatabaseProject.Data;
using Microsoft.Extensions.Configuration;

namespace DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string dbPath = @"Data Source=C:\Users\david\Downloads\StudentOptions (1).db;Mode=ReadWrite";

            Console.WriteLine(dbPath);
            StudentDB db = new(dbPath); //Make db class

            var names = db.GetUserNames();
            Console.WriteLine("Students:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            string[] fields = ["StudentID: ", "first name: ", "last name: ", "DOB: "];

            string currentParameter = string.Empty;
            string[] parameters = new string[fields.Length];


            foreach (var field in fields)
            {
                Console.WriteLine($"Please enter a {field}");
                currentParameter = Console.ReadLine();
                parameters.Append(currentParameter);
            }

            db.AddStudentRecord(parameters);
        }
    }
}
