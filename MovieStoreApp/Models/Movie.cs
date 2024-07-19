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
        public DateOnly ReleaseDate {  get; set; }

        public Movie(int id, string name, string genre, DateOnly releaseDate)
        {
            Id = id;
            Name = name;
            Genre = genre;
            ReleaseDate = releaseDate;
        }
        public static Movie AddMovie(int id, string name, string genre, DateOnly releaseDate)
        {
            return new Movie(id, name, genre, releaseDate);
        }
        public override string ToString()
        {
            return $"===========Movie===========\n" +
                $"Name : {Name}\n"+
                $"Id : {Id}\n" +
                $"Genre : {Genre}\n" +
                $"Release Date : {ReleaseDate}\n";
        }
    }
}
