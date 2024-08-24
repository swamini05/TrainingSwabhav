using TicTacToeFasade.Exceptions;

namespace TicTacToeFasade.Models
{
    internal class Board
    {
        private Cell[] cells;

        public Board()
        {
            cells = new Cell[9];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
            }
        }

        public bool IsBoardFull()
        {
            foreach (var cell in cells)
            {
                if (cell.IsEmpty())
                    return false;
            }
            return true;
        }

        public void SetCellMark(int loc, MarkType mark)
        {
            if (loc < 0 || loc >= cells.Length)
                throw new InvalidCellLocationException("The provided cell location does not exist");

            cells[loc].SetMark(mark);
        }

        public Cell GetCell(int index)
        {
            if (index < 0 || index >= cells.Length)
                throw new InvalidCellIndexException("The provided cell index is out of range.");

            return cells[index];
        }
    }
}
