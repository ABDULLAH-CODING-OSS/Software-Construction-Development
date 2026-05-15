
using Smart_Student_Course_Managment_System.Database;
using Smart_Student_Course_Managment_System.Menu;
using Smart_Student_Course_Managment_System.Services;

namespace Smart_Student_Course_Managment_System
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager db = new DatabaseManager();

            db.createTables();

            Console.WriteLine("Database & Tables Created Successfully!");
            MainMenu menu = new MainMenu();
            menu.showMenu();


        }
    }
}