using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPP.Models
{
    public class Movie
    {
        public int Id{get;set;}
        public string Tittle{get; set;}
        public string Director{get; set;}
        public int Year{get; set;}
        public int MoviePrice{get; set;}

        public bool IsAvailable {get; set;}
        public string Duration {get; set;}

        public Movie(int id,string tittle,string director, int year,int moviePrice)
        {
            Tittle = tittle ;
            Director = director;
            Year = year;
            MoviePrice = moviePrice;
            Id = id;
        }
         public string WriteToFileFormat()
        {
            return $"{Id}***{Tittle}***{Director}***{Year}***{MoviePrice}";
        }

        public static Movie ConvertToMovie(string MovieAllCustomer)
        {
           var cutomerConvert = MovieAllCustomer.Split("***");
            return new Movie(int.Parse(cutomerConvert[0]),cutomerConvert[1],cutomerConvert[2],int.Parse(cutomerConvert[3]),int.Parse(cutomerConvert[4]));
        }

        

       
    }
}