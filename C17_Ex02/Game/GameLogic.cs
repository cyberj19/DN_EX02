using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game.Player;
using C17_Ex02.Game.State;
using System.Collections.Generic;

namespace C17_Ex02.Game
{
    class GameLogic
    {
        private const int k_FirstAndOnlyItem = 0;
        private readonly Board<GameBoardCell> m_Board;
        private readonly GamePlayer[] m_Players;
        private readonly GameState m_State;
        private List<uint> m_IndicesOfPlayersThatAreStillPlaying;
        private GameResult? m_GameResult;

        public GameState State
        {
            get
            {
                return m_State;
            }
        }

        // should call IsGameOver atleast once before using this, otherwise an exception will be thrown
        // (This is what we want to happen in that case)
        public GameResult Result
        {
            get
            {
                return (GameResult)m_GameResult;
            }
        }
        
        public GameLogic(Board<GameBoardCell> i_Board, GamePlayer[] i_Players)
        {
            m_GameResult = null;
            m_Board = i_Board;
            m_Players = i_Players;
            m_State = new GameState((uint)i_Players.Length, i_Board.Rows, i_Board.Cols);
            m_IndicesOfPlayersThatAreStillPlaying = new List<uint>(m_Players.Length);
            for (uint i = 0; i < m_Players.Length; i++)
            {
                m_IndicesOfPlayersThatAreStillPlaying.Add(i);
            }
        }

        //todo: PRoblematic, users has acces to it
        // Set a game-move
        public void Set(Point i_Pos, uint i_PlayerIndex)
        {
            m_Board.Set(i_Pos, m_Players[i_PlayerIndex].GenereateCell());
            m_State.Set(i_Pos, i_PlayerIndex);
            updateIsGameOver(i_Pos);
        }

        // Check if a board cell is empty
        public bool IsEmptyCell(Point i_Move)
        {
            return m_Board.Get(i_Move).Type == GameBoardCell.eType.None;
        }

        // Check if a move is valid
        public bool IsMoveValid(Point i_Move)
        {
            return m_Board.IsInBounds(i_Move) && IsEmptyCell(i_Move);
        }

        // Check is game is over (The actual check is made once after each move)
        public bool IsGameOver()
        {
            return m_GameResult.HasValue;
        }

        // Check and update if a game is over
        private void updateIsGameOver(Point i_Pos)
        {
            m_GameResult = getGameResultIfGameOver(i_Pos);
        }

        // If game is over returns valid GameResult, otherwise null
        private GameResult? getGameResultIfGameOver(Point i_Pos)
        {
            GameResult? retGameResult = null;
            uint? loserIndex = null;

            retGameResult = getGameResultIfOnlyOnePlayerOrLessLeft();
            if (!retGameResult.HasValue)
            {
                if (IsBoardFull())
                {
                    m_IndicesOfPlayersThatAreStillPlaying.Clear();
                }
                else
                {
                    loserIndex = m_State.GetPlayerIfPointInFullLine(i_Pos, m_IndicesOfPlayersThatAreStillPlaying);
                    if (loserIndex.HasValue)
                    {
                        m_IndicesOfPlayersThatAreStillPlaying.Remove(loserIndex.Value);
                    }
                }

                retGameResult = getGameResultIfOnlyOnePlayerOrLessLeft();
            }

            return retGameResult;
        }

        // If only 1 or 0 players are still in game - returns game result.
        // If its a draw - no players will be left in game
        // If its a win - Only the winner stays in the game.
        private GameResult? getGameResultIfOnlyOnePlayerOrLessLeft()
        {
            GameResult? gameResult = null;

            switch (m_IndicesOfPlayersThatAreStillPlaying.Count)
            {
                case 0:
                    gameResult = new GameResult(GameResult.eResult.Draw);
                    break;
                case 1:
                    gameResult = new GameResult(GameResult.eResult.PlayerWon, m_IndicesOfPlayersThatAreStillPlaying[k_FirstAndOnlyItem]);
                    break;
                default:
                    break;
            }

            return gameResult;
        }

        // Converts Player's index to cell type
        public GameBoardCell.eType PlayerIndexToCellType(uint i_PlayerIndex)
        {
            return m_Players[i_PlayerIndex].CellType;
        }

        // Converts GameBoardCell to Player's index in the Player's array.
        public uint CellTypeToPlayerIndex(GameBoardCell.eType i_Type)
        {
            uint? retIndex = null;

            if (i_Type != GameBoardCell.eType.None)
            {
                for (uint i = 0; i < m_Players.Length; i++)
                {
                    if (i_Type == m_Players[i].CellType)
                    {
                        retIndex = i;
                    }
                }
            }

            return (uint)retIndex;
        }

        // Is the board Full.
        // note: This cannot be implemented in the Board class itself because there might be games where "Set" is not used uniquely on Board.
        // So the next calculation wont tell us that the board is full.
        public bool IsBoardFull()
        {
            return m_State.AreStatesFull();
        }
    }
}
