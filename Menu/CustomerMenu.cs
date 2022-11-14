using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Implimentation;
using SCAPP.Interface;
using SCAPP.Models;

namespace SCAPP.Menu
{
    public class CustomerMenu
    {
        ICustomerManager customerManager = new CoutomerManger();
        IBookingManager bookingManager = new BookingManager();
        IMovieManager movieManager = new MovieManager();
        Adminmenu abn = new Adminmenu();

        public void CustomMean()
        {
            Console.WriteLine("Enter 1 to register\nEnter 2 to login \n  enter 3 to book \nenter 4 to go back to menu : ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                RegisterCutomer();
            }
            else if (choice == 2)
            {
                LoginMenu();
            }
            else if (choice == 4)
            {
                MainMenu nm = new MainMenu();
                nm.WelcomeMenu();
            }
            else
            {
                Console.WriteLine("invalid input");

            }

        }


        public void RegisterCutomer()
        {
            Console.WriteLine("you are Welcome");

            Console.Write("First name: ");
            string fName = Console.ReadLine();
            Console.Write("Last name: ");
            string lName = Console.ReadLine();
            Console.Write(" Enter your Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your  pin: ");
            int pin = int.Parse(Console.ReadLine());
            Console.Write("Enter your phonenumber  : ");
            int phonenumber = int.Parse(Console.ReadLine());

            customerManager.CreateCutomer(fName, lName, email, pin, phonenumber);
            CustomMean();
        }
        public void LoginMenu()
        {
            Console.Write("Enter your email:d ");
            string email = Console.ReadLine();
            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());
            Customer customer = customerManager.Login(email, pin);
            if (customer != null)
            {
                Console.WriteLine("login successful");
                CustomerSubMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin");

            }
        }
        public void CustomerSubMenu()
        {
            int flag = 0;
            do
            {
                Console.WriteLine("\nEnter 1 for createbooking\nEnter 2 to AddMoneyToWallet\nEnter 3 to CheckWallet\n enter 4 to deletebooking ");
                Console.WriteLine("");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Createbookingmenu();
                        break;


                    case 2:
                        AddMoneyToWallet();
                        break;

                    case 3:
                        CheckWallet();
                        break;
                    case 4:
                        BookingDelete();
                        break;

                    default:
                        Console.Write("Invalid Input");
                        break;

                }
                 Console.WriteLine("\nEnter 1 to go through the it again\nEnter 2 to exit the program");
                flag = int.Parse(Console.ReadLine());
            } while (flag == 1);

          

        }


        public void Createbookingmenu()
        {
            Console.WriteLine(" YOU ARE WELLCOME TO ");
            Console.WriteLine("This are the available movies");
            movieManager.GetAllMovies();
            Console.WriteLine();
            Console.WriteLine(" enter your gmail ");
            string email = Console.ReadLine();
            Console.WriteLine(" ente the movie name  ");
            string movieName = Console.ReadLine();
            Console.Write("Enter your bookingDate (yyyy-mm-dd):  ");
            DateTime bookiningdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(" enter you sitnumber  ");
            string sitnumber = Console.ReadLine();
            Console.Write("Enter your movie date(yyyy-mm-dd): ");
            DateTime moviedate = DateTime.Parse(Console.ReadLine());

            bookingManager.CreateBooking(email, movieName, bookiningdate, sitnumber, moviedate);
            CustomerSubMenu();
        }
        void AddMoneyToWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your amount: ");
            double amount = double.Parse(Console.ReadLine());

            customerManager.AddMoneyToWallet(email, amount);
        }
        void CheckWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your phonenumber: ");
            int phonenumber = int.Parse(Console.ReadLine());

            Console.Write("You have successfully checked your balance");

            customerManager.CheckWallet(email, phonenumber);
        }

        void BookingDelete()
        {
            Console.WriteLine(" Enter the movie date yyyy/mm/dd");
            DateTime moiviesdates = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(" you have suceefully delete booking ");
            bookingManager.DeleteBooking(moiviesdates);

        }

    }
}