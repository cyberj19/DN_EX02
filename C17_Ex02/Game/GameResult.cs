namespace C17_Ex02.Game
{
    struct GameResult
    {
        public enum eResult
        {
            Draw,
            PlayerWon
        }

        private readonly eResult m_Result;
        private readonly uint? m_WinPlayerIndex;

        public eResult Result
        {
            get
            {
                return m_Result;
            }
        }

        public uint WinPlayerIndex
        {
            get
            {
                // if this wasnt set, an exception will be thrown. //todo: make sure
                return (uint)m_WinPlayerIndex;
            }
        }

        public GameResult(eResult i_Result)
        {
            m_Result = i_Result;
            m_WinPlayerIndex = null;
        }

        public GameResult(eResult i_Result, uint i_WinPlayerIndex)
        {
            m_Result = i_Result;
            m_WinPlayerIndex = i_WinPlayerIndex;
        }
    }
}
