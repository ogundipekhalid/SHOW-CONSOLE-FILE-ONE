using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Implimentation;
using SCAPP.Interface;
using SCAPP.Models;

namespace SCAPP.Menu
{
    public class Adminmenu
    {
        IAdminManager adminManager = new AdminManager();
        IMovieManager movieManager = new MovieManager();
        ICustomerManager CustomerManager = new CoutomerManger();
        public void AdminMean()
        {
            Console.WriteLine("\nEnter 1 to register\nEnter 2 to login\n Enter 3 to go back to menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                RegisterAdminMenu();

            }
            else if (choice == 2)
            {
                LoiginAdminMenu();
            }
            else if (choice == 3)
            {
                MainMenu nm = new MainMenu();
                nm.WelcomeMenu();
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }


        public void RegisterAdminMenu()
        {
            Console.WriteLine("\nWelcome ");
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lName = Console.ReadLine();
            Console.Write(" Enter your Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your  pin: ");
            int pin = int.Parse(Console.ReadLine());
            Console.Write("Enter your phonenumber: ");
            string phone = Console.ReadLine();
            adminManager.CreateAdmin(firstName, lName, email, pin, phone);
            AdminMean();
        }

        public void LoiginAdminMenu()
        {
            {

                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                Console.WriteLine("Enter pin");
                int pin = int.Parse(Console.ReadLine());
                Admin admin = adminManager.Login(email, pin);
                // System.Console.WriteLine(admin.PIN);
                if (admin != null)
                {
                    Console.WriteLine("login successful");
                    AdminSubMenu();
                }
                else
                {
                    Console.WriteLine("Wroung password");

                }
            }
        }

        public void AdminSubMenu()
        {
            Console.WriteLine("Enter 1 Crete  movie \nEnter 2 to view all movie\nEnter 3 Update movie \nEnter 4 update admindetails  \nEneter 5 to Delete movie \n Enter 6 to delete customer \nEnter 7 to go back ");
            int choce = int.Parse(Console.ReadLine());
            if (choce == 1)
            {
                // Adminmenu adminmenu = new Adminmenu();
                CreatMovie();
                AdminSubMenu();
            }
            else if (choce == 2)
            {
                movieManager.GetAllMovies();
                AdminSubMenu();
            }
            else if (choce == 3)
            {
                UpdateMoviDetaile();
                 AdminSubMenu();
            }
            else if (choce == 4)
            {
                // Adminmenu adminmenu = new Adminmenu();
                updateAdminDtls();
                AdminSubMenu();
            }
            else if (choce == 5)
            {
                DeletedMovie();
                 AdminSubMenu();
            }
             else if (choce == 6)
            {
                DeleteCutumer();
                AdminSubMenu();
            }
            else if (choce == 7)
            {
                AdminMean();
            }
            else
            {
                Console.WriteLine("invalid opt");
            }
        }

        public void CreatMovie()
        {
            Console.WriteLine(" You Are   Welcome ");
            Console.WriteLine(" Enter the movie tittle ");
            string title = Console.ReadLine();
            Console.WriteLine(" Enter  the   director :");
            string direcctor = (Console.ReadLine());
            Console.WriteLine("Enter the year :");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price :");
            int movePri = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the duration");
            string duration = (Console.ReadLine());
            movieManager.CreateMovie(title, direcctor, year, movePri, duration);
        }
        public void UpdateMoviDetaile()
        {
            Console.WriteLine(" enter the previous  price you want to update ");
            int movieprice = int.Parse(Console.ReadLine());
            Console.WriteLine(" enter the previous year to update ");
            int year = int.Parse(Console.ReadLine());
            movieManager.UpdateMovie(movieprice, year);
            // Console.WriteLine(" movie update sucessfully ");
            AdminSubMenu();

        }
        public void updateAdminDtls()
        {
            Console.WriteLine(" enter the first name you want to update ");
            string firstName = Console.ReadLine();
            Console.WriteLine(" enter the secoun name your  want to update ");
            string lastName = Console.ReadLine();
            adminManager.UpdateAdmin(firstName, lastName);
            //  System.Console.WriteLine(" admin update sucessfully ");
            AdminSubMenu();
        }

        public void DeletedMovie()
        {
            // Console.WriteLine("Enter the tittle ");
            // string tittle = Console.ReadLine();
            movieManager.DeleteMovie();
            AdminSubMenu();
        }
        public void DeleteCutumer()
        {
            Console.WriteLine("Enter the emil ");
            string gmail = Console.ReadLine();

            CustomerManager.DeleteCustomer(gmail);
        }
    }
}