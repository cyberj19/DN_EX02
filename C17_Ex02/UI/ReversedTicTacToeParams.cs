using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.Game.Player;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game;
using C17_Ex02.Utils;

namespace C17_Ex02.UI
{
    class ReversedTicTacToeParams
    {

        const uint k_BoardMinimalSize = 3;
        const uint k_BoardMaximalSize = 9;
        readonly static Point sr_MinimalPoint = new Point(1, 1);
        readonly static Point sr_MaximalPoint = new Point(k_BoardMaximalSize, k_BoardMaximalSize);

        //todo: pass to C'tor what is playaer 1 what is player 2, board size etc'

        public static eGameType GetGameType()
        {
            return (eGameType)ConsoleUtils.GetPositiveNumberFromUser(
                    @"Please Choose Game Type:
{0}. Player vs. Player
{1}. Player vs. Computer",
                (uint)eGameType.PlayerVsPlayer,
                (uint)eGameType.PlayerVsComputer);
        }

        public static uint GetBoardSize()
        {
            return ConsoleUtils.GetPositiveNumberFromUser(
                "Please Insert Board Size: ({0}-{1})",
                k_BoardMinimalSize,
                k_BoardMaximalSize);
        }
        /*
        public static void AskForMove(ePlayerID i_Player)
        {
            string i_MessageForUser = String.Format("Player {0} Turn:", i_Player);
            ConsoleUtils.GetPointFromUser(i_MessageForUser, sr_MinimalPoint, sr_MaximalPoint);

        }*/
}
}
