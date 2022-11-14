using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Models;

namespace SCAPP.Interface
{
    public interface IBookingManager 
    {
        public void  CreateBooking( string email,string movieName,  DateTime bookingDate,string sitNumber,  DateTime MovieDate);
        public void UpdateDateBooking();
        public void DeleteBooking(DateTime movieDate);
        public BookingCoustomer GetBooking (DateTime movieDate);
        public void GetAveilMoviesint (string movieName ,DateTime movieDate,int duration);
        public void ReadFromFile();
         public void  ReWriteToFile();
       
    }
}
