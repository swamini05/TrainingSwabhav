using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreApp.Exceptions;
using MovieStoreApp.Models;
using MovieStoreApp.Services;

namespace MovieStoreApp.Repository
{
    internal class MovieStoreManager
    {
        public static List<Movie> movieList = new List<Movie>();

        //public MovieStoreManager()
        //{
        //    movieList = DataSerializer.DeserializeMovieList();
        //}
        public static void ManageMovieStore()
        {
            movieList = DataSerializer.DeserializeMovieList();
        }
        public static void AddNewMovie(int id, string name, string genre, int releaseYear)
        {
            if (movieList.Count >= 5)
            {
                throw new MovieStoreCapacityFullException("The movie store capacity is full. Cannot add more movies!");
                return;
            }
            Movie movie = Movie.AddMovie(id, name, genre, releaseYear);
            movieList.Add(movie);
        }
        public static List<Movie> DisplayMovieStoreList()
        {
            if (movieList.Count == 0)
                throw new MovieStoreEmptyException("Movie store is empty");
            else
                return movieList;
        }
        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            findMovie = movieList.Where(item => item.Id == id).FirstOrDefault();
            if (findMovie != null)
                return findMovie;
            else
                throw new MovieNotFoundException("Movie not found");
        }
        public static void RemoveMovie(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie not found");
            else
            {
                movieList.Remove(findMovie);
            }
        }
        public static void ClearAllMovies()
        {
            if (movieList.Count == 0)
                throw new MovieStoreEmptyException("Movie store is empty");
            else
                movieList.Clear();
        }
        public static void ExitMovieStore()
        {
            DataSerializer.SerializeMovieList(movieList);
        }
    }
}
