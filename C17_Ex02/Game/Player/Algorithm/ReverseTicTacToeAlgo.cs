using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;

namespace C17_Ex02.Game.Player.Algorithm
{
    class ReverseTicTacToeAlgo
    {
        Board<int> m_RiskBoard;
        char m_Sign;
        char m_OpponentSign;
        List<Line> lines;
        int m_CurrentRisk;

        public ReverseTicTacToeAlgo(char i_Sign, uint i_BoardSize, List<Line> i_GameLines)
        {

            initBoard(i_BoardSize);
            this.m_Sign = i_Sign;
            this.lines = i_GameLines;
            this.m_CurrentRisk = 0;
            this.m_OpponentSign = (i_Sign == 'X') ? 'O' : 'X';
        }

        private void initBoard(uint i_BoardSize)
        {
            m_RiskBoard = new Board<int>(i_BoardSize, i_BoardSize);
        }

        private int getRisk(Point i_Pos)
        {
            int baseRisk = this.m_CurrentRisk;
            foreach (Line line in LineManager.GetLines(i_Pos))
            {
                if (line.HasSign(m_OpponentSign))
                {
                    if (line.HasSign(m_Sign))
                    {
                        continue;
                    }
                    else
                    {
                        baseRisk++;
                    }
                }
                else
                {
                    baseRisk++;
                }

            }

            return baseRisk;
        }
        public Point GetMove()
        {
            Point leastRiskyPos;
            List<Point> freePositions = SomeClass.GetFreePositions();
            List<Tuple<int, Point>> risks = null;

            freePositions.ForEach(pos => risks.Add(Tuple.Create(getRisk(pos), pos)));
            risks.Sort((x, y) => y.Item1.CompareTo(x.Item1));
            leastRiskyPos = risks[0].Item2;

            return leastRiskyPos;
        }

    }
}
