using TicTacToeFasade.Exceptions;

namespace TicTacToeFasade.Models
{
    internal class Cell
    {
        private MarkType mark;

        public Cell()
        {
            mark = MarkType.Empty;
        }

        public bool IsEmpty()
        {
            return mark == MarkType.Empty;
        }

        public MarkType GetMark()
        {
            return mark;
        }

        public void SetMark(MarkType newMark)
        {
            if (!IsEmpty())
                throw new CellAlreadyMarkedException("The cell is already marked and cannot be marked again.");

            mark = newMark;
        }
    }
}
