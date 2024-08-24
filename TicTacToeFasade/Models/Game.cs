namespace TicTacToeFasade.Models
{
    internal class Game
    {

        private Player player1;
        private Player player2;
        private Board board;
        private ResultAnalyzer resultAnalyzer;
        private int turn;

        public Game(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            board = new Board();
            resultAnalyzer = new ResultAnalyzer(board);
            turn = 1;
        }

        public bool IsGameOver()
        {
            resultAnalyzer.AnalyzeResult();
            return resultAnalyzer.GetResult() != ResultType.Progress;
        }

        public void Play(int cellIndex)
        {
            if (IsGameOver())
            {
                Console.WriteLine("The game is already over. No more moves can be made.");
                return;
            }

            Player currentPlayer = (turn % 2 == 1) ? player1 : player2;

            try
            {
                board.SetCellMark(cellIndex, currentPlayer.Symbol);

                if (IsGameOver())
                {
                    Console.WriteLine($"It's a {resultAnalyzer.GetResult()}!");
                }
                else
                {
                    turn++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
