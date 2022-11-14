using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Implimentation;
using SCAPP.Interface;

namespace SCAPP.Menu
{
    public class MainMenu
    {
        IAdminManager adminManager = new AdminManager();
        ICustomerManager CustomerManager = new CoutomerManger();
        IMovieManager movieManager = new MovieManager();
        IBookingManager bookingManager = new BookingManager();
        public void WelcomeMenu()
        {
           // Console.WriteLine("Reading");
            adminManager.ReadFromFile();

           // Console.WriteLine("Reading");
            CustomerManager.ReadFromFile();

           // Console.WriteLine("Reading");
            movieManager.ReadFromFile();

            //Console.WriteLine("Reading");
            bookingManager.ReadFromFile();            
       

            
            Console.WriteLine(" Welcome to Dilakh movie Center");
            Console.WriteLine(" Enter 1 as Admin \n Enter 2 as customer");
            int choik = int.Parse(Console.ReadLine());
            if (choik == 1)
            {
                Adminmenu vrb = new Adminmenu();
                vrb.AdminMean();
            }
            else if (choik == 2)
            {
                CustomerMenu cm = new CustomerMenu();
                cm.CustomMean();
            }

        }

    }
}