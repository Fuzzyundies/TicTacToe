using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum Mark
    {
        Empty = 0,
        X,
        O
    }

    struct Point
    {
        public int x;
        public int y;

        public Point(int fX, int fY)
        {
            x = fX;
            y = fY;
        }
    }

    class Grid
    {
        private Mark[,] _gridState;
        
        public Grid()
        {
            _gridState = new Mark[3, 3];
        }
        
        private Point GetAtPosition(int p)
        {
            switch (p)
            {
                case 1:
                    return new Point(0, 0);
                    break;

                case 2:
                    return new Point(1, 0);
                    break;

                case 3:
                    return new Point(2, 0);
                    break;

                case 4:
                    return new Point(0, 1);
                    break;

                case 5:
                    return new Point(1, 1);
                    break;

                case 6:
                    return new Point(2, 1);
                    break;

                case 7:
                    return new Point(0, 2);
                    break;

                case 8:
                    return new Point(1, 2);
                    break;

                case 9:
                    return new Point(2, 2);
                    break;

                default:
                    throw new ArgumentException("Position " + p + " does not exist.");
                    break;
            }
        }

        public Mark this[int x, int y]
        {
            get
            {
                return _gridState[x, y];
            }
            set
            {
                _gridState[x, y] = value;
            }
        }

        public Mark this[int p]
        {
            get
            {
                Point pnt = this.GetAtPosition(p);
                return this[pnt.x, pnt.y];
            }
            set
            {
                Point pnt = this.GetAtPosition(p);
                this[pnt.x, pnt.y] = value;
            }
        }
        
        public bool HasWinner()
        {
            if (this.Winner() == Mark.Empty)
                return false;
            else
                return true;
        }

        public Mark Winner()
        {
            if (WinCondition(Mark.X))
                return Mark.X;
            else if (WinCondition(Mark.O))
                return Mark.O;
            else
                return Mark.Empty; // There is no winner
        }

        private bool WinCondition(Mark mark)
        {
            // First Row
            if (this[0, 0] == mark && this[1, 0] == mark && this[2, 0] == mark)
            {
                return true;
            }

            //Second Row
            if (this[0, 1] == mark && this[1, 1] == mark && this[2, 1] == mark)
            {
                return true;
            }

            //Third Row
            if (this[0, 2] == mark && this[1, 2] == mark && this[2, 2] == mark)
            {
                return true;
            }

            //First Column
            if (this[0, 0] == mark && this[0, 1] == mark && this[0, 2] == mark)
            {
                return true;
            }

            //Second Column
            if (this[1, 0] == mark && this[1, 1] == mark && this[1, 2] == mark)
            {
                return true;
            }

            //Third Column
            if (this[2, 0] == mark && this[2, 1] == mark && this[2, 2] == mark)
            {
                return true;
            }

            //Diagonal Left -> Right
            if (this[0, 0] == mark && this[1, 1] == mark && this[2, 2] == mark)
            {
                return true;
            }

            //Diagonal Right -> Left
            if (this[2, 0] == mark && this[1, 1] == mark && this[0, 2] == mark)
            {
                return true;
            }
            return false;
        }

        public bool IsStalemate()
        {
            if (this.HasWinner())
                return false;

            if (this[1] != Mark.Empty || this[2] != Mark.Empty || this[3] != Mark.Empty ||
                this[4] != Mark.Empty || this[5] != Mark.Empty || this[6] != Mark.Empty ||
                this[7] != Mark.Empty || this[8] != Mark.Empty || this[9] != Mark.Empty)
            {
                return false;
            }

            return true;
        }

    }
}
