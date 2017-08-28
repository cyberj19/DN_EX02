namespace C17_Ex02.Game.State
{
    // Represents that state of a single board line (Will speed up checking if the game is over
    // and will help Algorithm-implementors)
    struct BoardLineState
    {
        public enum eLineType
        {
            Row,
            Col,
            Diagonal,
            AntiDiagonal
        }

        private readonly eLineType m_LineType;
        private readonly uint[] m_AmountOfCellsByPlayer;
        private readonly uint m_TotalNumberOfCells;
        private uint m_TotalAmountOfCellsUsed;

        public eLineType Type
        {
            get
            {
                return m_LineType;
            }
        }

        public BoardLineState(eLineType i_LineType, uint i_AmountOfPlayers, uint i_TotalLineLength)
        {
            m_LineType = i_LineType;
            m_AmountOfCellsByPlayer = new uint[i_AmountOfPlayers];
            m_TotalAmountOfCellsUsed = 0;
            m_TotalNumberOfCells = i_TotalLineLength;
        }

        // if atleast one 'set' was called on this line, find first player.
        // Otherwise, returns null
        public uint? GetFirstPlayerWithItemIndex()
        {
            uint? retIndex = null;

            for (uint i = 0; i < m_AmountOfCellsByPlayer.Length; i++)
            {
                if (m_AmountOfCellsByPlayer[i] > 0)
                {
                    retIndex = i;
                    break;
                }
            }

            return retIndex;
        }

        // Get the amount of cells in line of a speicifc player
        public uint GetAmountOfCellsUsedByPlayer(uint i_PlayerIndex)
        {
            return m_AmountOfCellsByPlayer[i_PlayerIndex];
        }

        // Is the line full
        public bool IsLineFull()
        {
            return m_TotalNumberOfCells == m_TotalAmountOfCellsUsed;
        }

        // Is the line full and all cells are of same player?
        public bool IsLineFullBySinglePlayer()
        {
            return IsLineFull() && (m_AmountOfCellsByPlayer[(uint)GetFirstPlayerWithItemIndex()] == m_TotalNumberOfCells);
        }

        // a 'set' was called for a cell in this line
        public void Set(uint i_PlayerIndex)
        {
            m_AmountOfCellsByPlayer[i_PlayerIndex]++;
            m_TotalAmountOfCellsUsed++; ;
        }
    }
}
