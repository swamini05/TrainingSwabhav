using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerApp.Models
{
    internal class Player
    {
        static int DEFAULT_AGE = 18;
        public int Id { get; }
        public string Name { get; }
        public int Age { get; } = DEFAULT_AGE;

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
            
        }
        public Player(int id,string name,int age):this(id,name) 
        {
            Age = age;
            
        }
        public static Player WhoIsElder(Player[] players)
        {
            Player elderPlayer = players[0];
            foreach (Player player in players)
            {
                if (player.Age > elderPlayer.Age)
                {
                    elderPlayer = player;
                }
            }
            return elderPlayer;
        }
    }
}
