// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using SCAPP.Implimentation;
using SCAPP.Menu;

class program
{
    static void Main(string[] args)
    {
        // BookingManager bookin = new BookingManager();
        // bookin.ReWriteToFile();
        // MovieManager mowe = new MovieManager();
        // mowe.ReWriteFile();
    //     CoutomerManger coutomerManger = new CoutomerManger();
    //     coutomerManger.ReWriteFile();
            //// Adminmenu mm = new AdminMenu();

        MainMenu mm = new MainMenu();
        mm.WelcomeMenu();

        // var movieManager = new MovieManager();
        // movieManager.ReadFromFile();
    }
}
