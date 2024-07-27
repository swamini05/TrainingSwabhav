using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieStoreLibrary.Models;

namespace MovieStoreLibrary.Services
{
    public class DataSerializer
    {
        static string filePath = "D:\\Training\\Assignments\\TrainingSwabhav\\MovieStoreManagementApp\\MovieStoreLibrary\\assets\\myMovies.json";
  
        public static void SerializeMovieList(List<Movie> movieList)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movieList));
            }
        }
        public static List<Movie> DeserializeMovieList()
        {
            if (!File.Exists(filePath))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                List<Movie> movieList = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return movieList;
            }
        }
    }
}
