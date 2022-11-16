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
            Console.Write("Enter your email : ");
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
                Console.WriteLine("\nEnter 1 to view all available movies  \nEnter 2 to  create booking\nEnter 3 to AddMoneyToWallet\nEnter 4 to CheckWallet\nEnter 5 to deletebooking \nEnter 6 to delet customer \nEnter 7 to logout");
                Console.WriteLine("");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        movieManager.GetAllMovies();
                        CustomerSubMenu();
                        break;
                    case 2:
                        Createbookingmenu();
                        break;


                    case 3:
                        AddMoneyToWallet();
                        CustomerSubMenu();
                        break;

                    case 4:
                        CheckWallet();
                        CustomerSubMenu();
                        break;
                    case 5:
                        BookingDelete();
                        CustomerSubMenu();
                        break;
                    case 6: 
                        DtlCutomer();
                         CustomerSubMenu();
                        break;
                    case 7: 
                       MainMenu mm = new MainMenu();
                        mm.WelcomeMenu();
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
            Console.WriteLine("Enter your gmail ");
            string email = Console.ReadLine();
            Console.WriteLine("Ente the movie name  ");
            string movieName = Console.ReadLine();
            Console.Write("Enter your bookingDate (yyyy-mm-dd):  ");
            DateTime bookiningdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter you a number to generate a number ");
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
            int password = int.Parse(Console.ReadLine());
            Console.Write("You have successfully checked your balance");
            customerManager.CheckWallet(email, password);
        }

        void BookingDelete()
        {
            Console.WriteLine(" Enter the movie date yyyy/mm/dd");
            DateTime moiviesdates = DateTime.Parse(Console.ReadLine());
            // Console.WriteLine(" you have suceefully delete booking ");
            bookingManager.DeleteBooking(moiviesdates);
        }
        void DtlCutomer()
        {
            Console.WriteLine(" Enter gmail ");
            string gmail = Console.ReadLine();
            customerManager.DeleteCustomer(gmail);
        }

    }
}