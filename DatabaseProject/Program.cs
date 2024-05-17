//using DatabaseProject.Data;
using Microsoft.Extensions.Configuration;

namespace DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string dbPath = @"Data Source=C:\Users\david\OneDrive\Documents\Programming stuff\SQLite\studentDBtemp.db;Mode=ReadWrite";

            Console.WriteLine(dbPath);
            StudentDB db = new(dbPath); //Make db class

            var names = db.GetUserNames();
            Console.WriteLine("Students:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //Console.WriteLine("Please enter a name to add:");
            //string newName = Console.ReadLine() ?? string.Empty;
            //db.AddUserName(newName);
        }
    }
}
