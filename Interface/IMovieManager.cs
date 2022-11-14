using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Models;

namespace SCAPP.Interface
{
    public interface IMovieManager
    {
       
         public void CreateMovie(string tittle,string director, int year,int MoviePrice  ,string Duration );
         public void UpdateMovie(int movieprice,int year);
       
         public Movie GetMovie(string tIttle);
          public void DeleteMovie();
        public void GetAllMovies();
        public void ReadFromFile();
          public void ReWriteFile();
       
    }
}