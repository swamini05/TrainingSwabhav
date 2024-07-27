using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieStoreApp.Models;

namespace MovieStoreApp.Services
{
    internal class DataSerializer
    {
        static string filePath = ConfigurationManager.AppSettings["filePath"].ToString();

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
