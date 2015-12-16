using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// A Mark represents who owns a position on a Grid.
    /// </summary>
    enum Mark
    {
        Empty = 0,
        X,
        O
    }

    /// <summary>
    /// A point refers to a given position on a Grid, and consists of an X and Y coordinate.
    /// </summary>
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

    /// <summary>
    /// A Grid represents the current game state.
    /// </summary>
    class Grid
    {
        /// <summary>
        /// Two-dimensional array that represents the grid, each position containing a Mark
        /// </summary>
        private Mark[,] _gridState;
        
        /// <summary>
        /// Constructs a new 3x3 grid
        /// </summary>
        public Grid()
        {
            this._gridState = new Mark[3, 3];
        }

        /// <summary>
        /// Constructs a 3x3 grid copied from another grid's gridstate (used by Clone())
        /// </summary>
        /// <param name="otherGridState"></param>
        private Grid(Mark[,] otherGridState)
        {
            this._gridState = otherGridState;
        }
        
        /// <summary>
        /// Takes an integer that represents a slot on the grid and returns its X and Y coordinates as a Point.
        /// </summary>
        /// <param name="p">Integer value from 1-9</param>
        /// <returns></returns>
        private Point GetAtPosition(int p)
        {
            switch (p)
            {
                case 1:
                    return new Point(0, 0);

                case 2:
                    return new Point(1, 0);

                case 3:
                    return new Point(2, 0);

                case 4:
                    return new Point(0, 1);

                case 5:
                    return new Point(1, 1);

                case 6:
                    return new Point(2, 1);

                case 7:
                    return new Point(0, 2);

                case 8:
                    return new Point(1, 2);

                case 9:
                    return new Point(2, 2);

                default:
                    throw new ArgumentException("Position " + p + " does not exist.");
            }
        }

        /// <summary>
        /// Gets or sets the Mark at position [x,y]
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        public Mark this[int x, int y]
        {
            get
            {
                return this._gridState[x, y];
            }
            set
            {
                this._gridState[x, y] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Mark at position p
        /// </summary>
        /// <param name="p">Position</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Returns true if the grid has a winner
        /// </summary>
        /// <returns></returns>
        public bool HasWinner()
        {
            if (this.Winner() == Mark.Empty)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns the winning Mark on the grid, or Mark.Empty if there is no winner.
        /// </summary>
        /// <returns></returns>
        public Mark Winner()
        {
            if (WinCondition(Mark.X))
                return Mark.X;
            else if (WinCondition(Mark.O))
                return Mark.O;
            else
                return Mark.Empty; // There is no winner
        }

        /// <summary>
        /// Checks to see if the specified Mark is a winner
        /// </summary>
        /// <param name="mark">Mark to check</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns true if all slots on the grid are filled and no winner exists.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a deep copy clone of this Grid
        /// </summary>
        /// <returns></returns>
        public Grid Clone()
        {
            Mark[,] newGridState = new Mark[3, 3];

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    newGridState[x, y] = this[x, y];
                }
            }

            return new Grid(newGridState);
        }

        /// <summary>
        /// Returns a list of all positions that are empty
        /// </summary>
        /// <returns></returns>
        public List<int> PossibleMoves()
        {
            List<int> returnList = new List<int>();

            for (int i = 1; i <= 9; i++)
            {
                if (this[i] == Mark.Empty)
                    returnList.Add(i);
            }

            return returnList;
        }
    }
}
