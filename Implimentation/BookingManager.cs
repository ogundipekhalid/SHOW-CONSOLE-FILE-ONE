using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Interface;
using SCAPP.Models;

namespace SCAPP.Implimentation
{
    public class BookingManager : IBookingManager
    {
        public static List<BookingCoustomer> listOfBookings = new List<BookingCoustomer>();
        
         MovieManager movie = new MovieManager();
         CoutomerManger customer = new CoutomerManger();
         public string BookinFilePath = "./File/Booking.txt";
       
        public void CreateBooking(string email,string movieName,  DateTime bookingDate,string sitNumber,  DateTime MovieDate)

        {

            var movieDate = DateTime.Now;
            var bokingDate = DateTime.Now;
            Random ran = new Random();
            int id = listOfBookings.Count + 1;
            var verifyMovieName = movie.GetMovie(movieName);
            var verifyEmail = customer.GetCustomer(email);
            double wallet = 0;
            if(verifyEmail == null)
            {
                Console.WriteLine("unrecognized email");
            }
            else
            {
                if(verifyMovieName == null)
                {
                    Console.WriteLine( "movie name does not exist");
                }
                else
                {
                    string MovieName = movieName; 
                    string sitnumber =  new Random(id).Next(001 ,600).ToString();
                    bool isAvailable = true;
                    int duration = 2;
                    BookingCoustomer books = new BookingCoustomer( id,  movieName,  bookingDate,  sitNumber,  movieDate, isAvailable,  duration,  email);
                    Console.WriteLine($"your sit number is {sitnumber} and you have  successfully book a movie ....  ");        
                    listOfBookings.Add(books);
                      using (StreamWriter writer = new StreamWriter(BookinFilePath, append: true))
                    {
                        writer.WriteLine(books.WriteToFileFormat());
                    }
                    Console.WriteLine("created succesfully");
                    
                }
                
            }
           
        }
        
        public void DeleteBooking(DateTime movieDate)
        {
         Console.WriteLine("Enter email of Admin to delete: ");
            string email = Console.ReadLine().Trim();
            foreach (var item in listOfBookings)
            {
                if (item.Email == email)
                {
                    listOfBookings.Remove(item);
                    ReWriteToFile();
                    break;
                }
            }
            Console.WriteLine("deleted succesfully");

        }
        
       

        public void GetAveilMoviesint(string movieName, DateTime movieDate, int duration)
        {
            foreach (var item in listOfBookings)
           {
                if (item.MovieName == movieName && item.MovieDate == movieDate && item.Duration == duration)
                {
                    Console.WriteLine($"You have successfully booked a movie for yourself");
                }
           }
        }

        public BookingCoustomer GetBooking(DateTime movieDate)
        {
            foreach (var booking in listOfBookings)
            {
                if (booking.BookingDate == movieDate)
                {
                    return booking;
                }
            }
            return null;
        }

         public void UpdateDateBooking()
        {
           Console.WriteLine("Enter moviedate of  to Update: ");
            DateTime movieDate  = DateTime.Parse(Console.ReadLine().Trim());
            BookingCoustomer bootoUpdate  = GetBooking(movieDate);
            if (bootoUpdate != null)
            {
                Console.WriteLine("Update moviedate : ");
               DateTime moviedate =DateTime.Parse(Console.ReadLine().Trim());
                bootoUpdate.MovieDate = moviedate;

                Console.WriteLine("Update bookindate : ");
                DateTime bookingdate  =DateTime.Parse(Console.ReadLine().Trim());
                bootoUpdate.BookingDate = bookingdate;

                Console.WriteLine("Update Post: ");
                string sitnumber = Console.ReadLine().Trim();
                bootoUpdate.SitNumber = sitnumber;
                 ReWriteToFile();
               
                Console.WriteLine("booking updated successfully");
            }
            else
            {
                Console.WriteLine("booking not found");
            }
        }    
         public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(BookinFilePath))
            {
                while (reader.Peek() > -1)
                {
                    string bookinginInfo = reader.ReadLine();
                  listOfBookings.Add(BookingCoustomer.ConvertToBooking(bookinginInfo));
                }
            }
        }

          
        public void  ReWriteToFile()
        {
            File.WriteAllText(BookinFilePath,string.Empty);
            {
                using (StreamWriter writer  = new StreamWriter(BookinFilePath, append : true))
                {
                    foreach (var book in listOfBookings)
                    {
                        writer.WriteLine(book.WriteToFileFormat());
                    }
                }
            }
        }
    }
    
}
           