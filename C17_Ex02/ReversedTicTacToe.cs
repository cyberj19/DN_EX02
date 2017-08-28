using System;
using C17_Ex02.Game;
using C17_Ex02.UI;
using C17_Ex02.Game.Player;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Utils;
using System.Collections.Generic;

namespace C17_Ex02
{
    class ReversedTicTacToe
    {       
        static public void Run()
        {
            GameManager currentGame;

            //todo: Get params from ui here
            //Ui.GetParams

            /// todo: NOT THIS WAY
            /// //todo 2# currently both players computer
            /// 

            GamePlayer[] players = new GamePlayer[2] { new GamePlayer(GamePlayer.eType.ComputerPlayer, GameBoardCell.eType.X),
                                                        new GamePlayer((ReversedTicTacToeParams.GetGameType()==eGameType.PlayerVsPlayer)?GamePlayer.eType.HumanPlayer:GamePlayer.eType.ComputerPlayer, GameBoardCell.eType.O)};
            ///

            while (true)
            {
                //todo: run until input from user "Q"
                currentGame = new GameManager(ReversedTicTacToeParams.GetBoardSize(), players);

                while (!currentGame.IsGameOver())
                {
                    Point? inputForCurrTurn = null;


                    GameManager.eMoveResult currMoveResult;
                    do
                    {
                        if (currentGame.IsInputRequiredForCurrentTurn())
                        {
                           // ReversedTicTacToeParams.AskForMove(ePlayerID.PlayerX);
                            break;
                            //todo:... get input! (do function getInput())
                        }

                        currMoveResult = currentGame.MakeGameMove(inputForCurrTurn);
                    } while (currMoveResult == GameManager.eMoveResult.BadInput);
                    //todo: is blank line required
                    //todo: PRINT GAME HERE ui.printboard....
                    //todo: return error (Move result error..)
                    ConsoleUI.DrawBoard(currentGame.Board);
                }

                //todo: Print some status about the game who won etc'

                /////todo: Currently quitting when game is over, remove next line
                break;
            }
        }
    }
}
