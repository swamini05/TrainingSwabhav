using System.Configuration;
using System.Text.Json;
using MovieStoreApp.Exceptions;
using MovieStoreApp.Models;
using MovieStoreApp.Repository;
using MovieStoreApp.Services;
using MovieStoreApp.ViewControllers;

namespace MovieStoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
                MovieStore.DisplayMenu();
        }
    }
}
