using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApp.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear {  get; set; }

        public Movie(int id, string name, string genre, int releaseYear)
        {
            Id = id;
            Name = name;
            Genre = genre;
            ReleaseYear = releaseYear;
        }
        public static Movie AddMovie(int id, string name, string genre, int releaseYear)
        {
            return new Movie(id, name, genre, releaseYear);
        }
        public override string ToString()
        {
            return $"===========Movie===========\n" +
                $"Name : {Name}\n"+
                $"Id : {Id}\n" +
                $"Genre : {Genre}\n" +
                $"Release Year : {ReleaseYear}\n";
        }
    }
}
