namespace TicTacToeFasade.Models
{
    internal class Player
    {
        public string Name { get; private set; }
        public MarkType Symbol { get; private set; }

        public Player(string name, MarkType symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
