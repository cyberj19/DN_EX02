namespace C17_Ex02.BasicDataTypes
{
    // Represents a board with type 'T' Cells
    class Board<T>
    {
        private readonly T[,] m_Cells;
        private readonly uint m_NumRows;
        private readonly uint m_NumCols;

        public uint Rows
        {
            get
            {
                return m_NumRows;
            }
        }

        public uint Cols
        {
            get
            {
                return m_NumCols;
            }
        }
        
        public Board(uint i_NumRows, uint i_NumCols)
        {
            m_NumRows = i_NumRows;
            m_NumCols = i_NumCols;
            m_Cells = new T[i_NumRows, i_NumCols];
        }

        // check if position is in bounds of the board
        public bool IsInBounds(Point i_Pos)
        {
            return (i_Pos.X < m_NumCols) && (i_Pos.Y < m_NumRows);
        }

        // Set cell of specific index
        public void Set(Point i_Pos, T i_NewCell)
        {
            m_Cells[i_Pos.Y, i_Pos.X] = i_NewCell;
        }

        // Get cell at specific index
        public T Get(Point i_Pos)
        {
            return m_Cells[i_Pos.Y, i_Pos.X];
        }
    }
}