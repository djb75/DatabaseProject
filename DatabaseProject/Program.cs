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
            StudentDB db = new(dbPath);

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


            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Please enter a {fields[i]}");
                currentParameter = Console.ReadLine();
                parameters[i] = currentParameter;
            }

            db.AddStudentRecord(parameters);
        }
    }
}
