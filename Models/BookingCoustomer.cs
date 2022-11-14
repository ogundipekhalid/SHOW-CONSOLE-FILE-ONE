using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPP.Models
{
    public class BookingCoustomer
    {
        public string Email {get; set;}
        public int Id {get; set;}
        public string MovieName{get;set;}
        public DateTime BookingDate {get; set;}
        public   string SitNumber{get;set;}
        public DateTime MovieDate{get;set;}
        public bool IsAvailable {get; set;}
        public int Duration {get; set;}
        public double Price  {get; set;}

        public BookingCoustomer(int id, string movieName, DateTime bookingDate, string sitNumber, DateTime movieDate,bool isAvailable,int duration ,string email)
        {
            Email = email;
            Id = id;
            MovieName = movieName;
            SitNumber = sitNumber;
            MovieDate = movieDate;
            IsAvailable = isAvailable;
            Duration = duration;
            BookingDate = bookingDate;
        }
         public string WriteToFileFormat()
        {
            return $"{Id}***{Email}***{BookingDate}***{SitNumber}***{MovieDate}***{IsAvailable}***{Duration}***{Email}";
        }

        public static BookingCoustomer ConvertToBooking(string BookimAllCustomer)
        {
           var cutomerConvert = BookimAllCustomer.Split("***");
            return new  BookingCoustomer(int.Parse(cutomerConvert[0]),cutomerConvert[1],DateTime.Parse(cutomerConvert[2]),
            cutomerConvert[3],DateTime.Parse(cutomerConvert[4]),bool.Parse(cutomerConvert[5]),int.Parse(cutomerConvert[6]),cutomerConvert[7]);

        }

        
    }
}