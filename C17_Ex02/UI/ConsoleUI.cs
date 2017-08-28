using System;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game;
using C17_Ex02.Utils;
using System.Collections.Generic;
using C17_Ex02.Game.Player;

namespace C17_Ex02.UI
{
    class ConsoleUI
    {

        const byte k_NumberOfSignsPerColumn = 4;


        public static void PrintScoreList(List<int> i_Scores)
        {
            //todo: No.
            //todo : Create Players class
            /*
            int i = 0;

            System.Console.WriteLine("The Current Scores Are:");
            foreach (int score in i_Scores)
            {
                System.Console.WriteLine((ePlayerID)i++ + ": " + score);
            }*/
        }

        public static void DrawBoard(Board<GameBoardCell> i_Board)
        {
            byte counter = 1;

            System.Threading.Thread.Sleep(1000);
            Ex02.ConsoleUtils.Screen.Clear();
            Console.Write(ConsoleUtils.k_SpaceChar.ToString());
            for (int i = 1; i <= i_Board.Cols; i++)
            {
                Console.Write(ConsoleUtils.k_SpaceChar + i.ToString() + ConsoleUtils.k_SpaceChar + ConsoleUtils.k_SpaceChar);
            }

            Console.WriteLine();

            // Run over the board
            ConsoleUtils.PrintNumericMargins("{0}" + ConsoleUtils.k_ColumnsDelimiter, counter++);
            for (uint currRow = 0; currRow < i_Board.Rows; currRow++)
            {
                for (uint currCol = 0; currCol < i_Board.Cols; currCol++)
                {
                    GameBoardCell currCell = i_Board.Get(new Point(currCol, currRow));
                    Console.Write(ConsoleUtils.k_SpaceChar + currCell.ToString() + ConsoleUtils.k_SpaceChar + ConsoleUtils.k_ColumnsDelimiter);
                }

                // print border
                ConsoleUtils.PrintBorder(ConsoleUtils.k_BorderUnitSign, i_Board.Cols * k_NumberOfSignsPerColumn, ConsoleUtils.k_SpaceChar.ToString() + ConsoleUtils.k_BorderUnitSign.ToString());

                if ((currRow + 1) != i_Board.Rows)
                {
                    ConsoleUtils.PrintNumericMargins("{0}" + ConsoleUtils.k_ColumnsDelimiter, counter++);
                }
            }
        }
    }
}
