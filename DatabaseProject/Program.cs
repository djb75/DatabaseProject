//using DatabaseProject.Data;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace DatabaseProject
{
    internal class Program
    {
        static void PrintAllStudentRecords(StudentDB db)
        {
            var studentRecords = db.GetStudentRecords();
            Console.WriteLine("Students:");
            Console.WriteLine("StudentID FirstName LastName DOB");
            foreach (string[] studentRecord in studentRecords)
            {
                Console.WriteLine(string.Join(' ', studentRecord));
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            const string dbPath = @"Data Source=C:\Users\david\Downloads\StudentOptions (1).db;Mode=ReadWrite";

            Console.WriteLine(dbPath);
            StudentDB db = new(dbPath);

            PrintAllStudentRecords(db);

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
