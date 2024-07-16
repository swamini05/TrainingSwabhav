using System.Security.Principal;
using PlayerApp.Models;

namespace PlayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[]
            {
                new Player (101, "Allen"),
                new Player(102, "Mary", 22),
                new Player(102,"Swamini",21),
                new Player(104,"Swati",24),
                new Player(105,"abc",28)
            };
            Player elderPlayer = Player.WhoIsElder(players);
            Console.WriteLine($"Elder Player: ID = {elderPlayer.Id}, Name = {elderPlayer.Name}, Age = {elderPlayer.Age}");
        }

    }
}

