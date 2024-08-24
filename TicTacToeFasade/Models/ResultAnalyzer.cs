namespace TicTacToeFasade.Models
{
    internal class ResultAnalyzer
    {
        private Board board;
        private ResultType result;

        public ResultAnalyzer(Board board)
        {
            this.board = board;
            result = ResultType.Progress;
        }

        private void HorizontalWinCheck()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (board.GetCell(i).GetMark() == board.GetCell(i + 1).GetMark() &&
                    board.GetCell(i + 1).GetMark() == board.GetCell(i + 2).GetMark() &&
                    !board.GetCell(i).IsEmpty())
                {
                    result = ResultType.Win;
                    return;
                }
            }
        }

        private void VerticalWinCheck()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board.GetCell(i).GetMark() == board.GetCell(i + 3).GetMark() &&
                    board.GetCell(i + 3).GetMark() == board.GetCell(i + 6).GetMark() &&
                    !board.GetCell(i).IsEmpty())
                {
                    result = ResultType.Win;
                    return;
                }
            }
        }

        private void DiagonalWinCheck()
        {
            if (board.GetCell(0).GetMark() == board.GetCell(4).GetMark() &&
                board.GetCell(4).GetMark() == board.GetCell(8).GetMark() &&
                !board.GetCell(0).IsEmpty())
            {
                result = ResultType.Win;
                return;
            }

            if (board.GetCell(2).GetMark() == board.GetCell(4).GetMark() &&
                board.GetCell(4).GetMark() == board.GetCell(6).GetMark() &&
                !board.GetCell(2).IsEmpty())
            {
                result = ResultType.Win;
            }
        }

        public void AnalyzeResult()
        {
            HorizontalWinCheck();
            if (result == ResultType.Win) return;

            VerticalWinCheck();
            if (result == ResultType.Win) return;

            DiagonalWinCheck();
            if (result == ResultType.Win) return;

            if (board.IsBoardFull())
                result = ResultType.Draw;
        }

        public ResultType GetResult()
        {
            return result;
        }
    }
}
