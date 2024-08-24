using TicTacToeFasade.Models;

namespace TicTacToeFasade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("player1", MarkType.X);
            Player player2 = new Player("player2", MarkType.O);


            Game game = new Game(player1, player2);

            game.Play(0);
            game.Play(1);
            game.Play(2);
            game.Play(4);
            game.Play(3);
            game.Play(6);
            game.Play(5);
            game.Play(8);
            game.Play(7);



        }
    }
}
