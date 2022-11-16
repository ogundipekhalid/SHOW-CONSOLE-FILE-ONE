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
       

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>");
            Console.WriteLine(" << WELCOME TO DILAKH MOVIE CENTER >>");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>");
            Console.WriteLine(" Enter 1 as Admin \n Enter 2 as customer");
            int choik = int.Parse(Console.ReadLine());
            if (choik == 1)
            {
                if (choik == 1)
                {
                    Console.WriteLine("\nENTER   ADMIN PASSWORD ENCODE  ADMIN TO  REGISTER ADMIN  ");
                    int check = int.Parse(Console.ReadLine().ToString());
                    {
                        if (check == 88)
                        {
                        Console.WriteLine(" acess true outcode  input ");
                        Adminmenu vrb = new Adminmenu();
                        vrb.AdminMean();
                        }
                         else
                        {
                            System.Console.WriteLine(" invalid input ");   
                        }
                    }
                   
                    
                    
                }
            }
            else if (choik == 2)
            {
                CustomerMenu cm = new CustomerMenu();
                cm.CustomMean();
            }

        }

    }
}