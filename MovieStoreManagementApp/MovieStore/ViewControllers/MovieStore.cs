using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MovieStoreLibrary.Exceptions;
using MovieStoreLibrary.Repository;

namespace MovieStoreManagement.ViewControllers
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            MovieStoreManager.ManageMovieStore();
            Console.WriteLine("Welcome to movie store developed by : Swamini");
            while (true)
            {
                Console.WriteLine("\nWhat do you wish to do?\n" +
                    "1.Add New Movie\n" +
                    "2.Display All Movie\n" +
                    "3.Find Movie by Id\n" +
                    "4.Remove Movie by Id\n" +
                    "5.Clear All Movie\n" +
                    "6.Exit");

                Console.Write("Choose an option: ");

                try
                {
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        throw new ChoiceFormatException("Invalid input. Please enter a valid integer between 1 and 6.");
                    }
                    DoTask(choice);
                }
                catch (ChoiceFormatException ce)
                {
                    Console.WriteLine(ce.Message);
                }
                catch (MovieStoreCapacityFullException msc)
                {
                    Console.WriteLine(msc.Message);
                }
                catch (MovieNotFoundException mnf)
                {
                    Console.WriteLine(mnf.Message);
                }
                catch (MovieStoreEmptyException mse)
                {
                    Console.WriteLine(mse.Message);
                }
                catch (DateFormatException de)
                {
                    Console.WriteLine(de.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddMovie();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    FindById();
                    break;
                case 4:
                    Remove();
                    break;
                case 5:
                    MovieStoreManager.ClearAllMovies();
                    Console.WriteLine("All movies cleared");
                    break;
                case 6:
                    MovieStoreManager.ExitMovieStore();
                    Environment.Exit(0);
                    break;
                default:
                    throw new ChoiceFormatException("Invalid input. Please enter a number between 1 and 6.");
                    break;
            }
        }
        static void AddMovie()
        {
            MovieStoreManager.CheckCapacity();
            Console.Write("Enter movie ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            //int releaseYear;
            Console.Write("Enter release year: ");
            int releaseYear = Convert.ToInt32(Console.ReadLine());
            if (releaseYear.ToString().Length != 4)
            {
                throw new FormatException("Release year must be a 4-digit number.");
            }
            MovieStoreManager.AddNewMovie(id, name, genre, releaseYear);
            Console.WriteLine("Movie added successfully.\n");
        }
        static void Display()
        {
            var movieList = MovieStoreManager.DisplayMovieStoreList();
            movieList.ForEach(movie=>Console.WriteLine(movie));
        }
        static void FindById()
        {
            Console.Write("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var movie = MovieStoreManager.FindMovieById(id);
            Console.WriteLine(movie);
        }
        static void Remove()
        {
            Console.Write("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieStoreManager.RemoveMovie(id);
            Console.WriteLine("Movie Deleted successfully\n");
        }
    }
}
