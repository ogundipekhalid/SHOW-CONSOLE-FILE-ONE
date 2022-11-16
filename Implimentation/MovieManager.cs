using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Interface;
using SCAPP.Models;

namespace SCAPP.Implimentation
{
    public class MovieManager : IMovieManager
    {
        public string FilePath = "./File/Movie.txt";
        public static List<Movie> listOfMovie = new List<Movie>();
        public void CreateMovie(string tittle, string director, int year, int MoviePrice, string Duration)
        {
            int id = listOfMovie.Count + 1;
            int moviePrice = 2000;
            Random rand = new Random();
            int Id = rand.Next(100, 999);
            Movie movie = new Movie(id, tittle, director, year, MoviePrice);
            listOfMovie.Add(movie);
            Console.WriteLine($" MVB{tittle} surcessfly  created ");
            using (StreamWriter write = new StreamWriter(FilePath, append: true))
            {
                write.WriteLine(movie.WriteToFileFormat());
            }
            Console.WriteLine("created sucessfully");

        }
             public void DeleteMovie()
             {
                 
            Console.WriteLine("Enter Tittle of movie to delete: ");
            string title = Console.ReadLine().Trim();
            foreach (var item in listOfMovie)
            {
                if (item.Tittle == title)
                {
                    listOfMovie.Remove(item);
                    ReWriteFile();
                    break;
                }
            }
            Console.WriteLine("Delete succesfully");
        }
    
        public Movie GetMovie(string tIttle)
        {
            foreach (var item in listOfMovie)
            {
                if (item.Tittle == tIttle)
                {
                    return item;
                }
            }
            return null;
        }

        public void GetAllMovies()
        {
            foreach (var item in listOfMovie)
            {
                Console.WriteLine($"S/N{item.Id}: Movie name = {item.Tittle}: year = {item.Year}: Movie Price = {item.MoviePrice}");
            }

        }

        public void UpdateMovie(int movieprice,int year)
        {
            Console.WriteLine("Enter the previous tittle  of movie to Update: ");
            string title = Console.ReadLine().Trim();
            Movie MovieToUpdate = GetMovie(title);
            if (MovieToUpdate != null)
            {
                Console.WriteLine("Update the new  Movie Price : ");
                int moviePrice  = int.Parse(Console.ReadLine().Trim());
                MovieToUpdate.MoviePrice = moviePrice;

                Console.WriteLine("Update the new  year : ");
                int years  = int.Parse(Console.ReadLine().Trim());
                MovieToUpdate.Year = years;

                Console.WriteLine("Update new tittle: ");
                string tittlle = Console.ReadLine().Trim();
                MovieToUpdate.Tittle = tittlle;
                ReWriteFile();
                Console.WriteLine("movie updated successfully");
            }
            else
            {
                Console.WriteLine("movie not found");
            }
        }
        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string movieInfo = reader.ReadLine();
                    listOfMovie.Add(Movie.ConvertToMovie(movieInfo));
                }
            }
        }


        public void ReWriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            {
                using (StreamWriter writer = new StreamWriter(FilePath, append: true))
                {
                    foreach (var muvie in listOfMovie)
                    {
                        writer.WriteLine(muvie.WriteToFileFormat());
                    }
                }
            }

        }

    }
}