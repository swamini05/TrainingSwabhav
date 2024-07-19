using MovieStoreApp.Models;

namespace MovieStoreApp
{
    internal class Program
    {
        static List<Movie> movieList = new List<Movie>();
        static void Main(string[] args)
        {
            DisplayMenu();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Welcome to movie store developed by : Swamini\n");
            while (true)
            {
                Console.WriteLine("What do you wish to do?\n" +
                    "1.Add New Movie\n" +
                    "2.Display All Movie\n" +
                    "3.Find Movie by Id\n" +
                    "4.Remove Movie by Id\n" +
                    "5.Clear All Movie\n" +
                    "6.Exit");

                Console.Write("Choose an option: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewMovie();
                    break;
                case 2:
                    if (movieList.Count == 0)
                        Console.WriteLine("No movies to display.\n");
                    else
                        movieList.ForEach(movie => Console.WriteLine(movie));
                    break;
                case 3:
                    Movie findMovie = FindMovieById();
                    if (findMovie != null)
                        Console.WriteLine(findMovie);
                    else
                        Console.WriteLine("Movie Not Found!\n");
                    break;
                case 4:
                    RemoveMovie();
                    break;
                case 5:
                    if (movieList.Count == 0)
                        Console.WriteLine("Movie List is already Empty.\n");
                    else
                        movieList.Clear();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
        static void AddNewMovie()
        {
            if (movieList.Count >= 5)
            {
                Console.WriteLine("Movie store is full. Cannot add more movies.\n");
                return;
            }

            Console.Write("Enter movie ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter release date (YYYY-MM-DD): ");
            DateOnly releaseDate = DateOnly.Parse(Console.ReadLine());

            Movie movie = Movie.AddMovie(id,name,genre,releaseDate);
            movieList.Add(movie);
            Console.WriteLine("Movie added successfully.\n");
        }
        static Movie FindMovieById()
        {
            Movie findMovie = null;
            Console.Write("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            findMovie = movieList.Where(item => item.Id == id).FirstOrDefault();
            return findMovie;
        }
        static void RemoveMovie()
        {
            Movie findMovie = FindMovieById();
            if (findMovie == null)
                Console.WriteLine("Account Not Found!\n");
            else
            { 
                movieList.Remove(findMovie);
                Console.WriteLine("Movie Deleted successfully\n");
            }
        }

    }
}
