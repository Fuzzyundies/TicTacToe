using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ComputerTurn : Turn //Inherit from Turn
    {
        public enum Difficulty //Enumeration is a list of possible values
        {
            Hard, Medium, Easy
        }

        public ComputerTurn(Difficulty HowHard, Grid grid) : base(grid)
        {
            if(HowHard == Difficulty.Hard)
            {
                //Will always play perfect
            }

            else
            {
                Random rnd = new Random();
                int r = rnd.Next(1, 11);
                switch(HowHard)
                {
                    case Difficulty.Medium:
                        if (r > 5)
                        {
                            //Will play perfect turn
                        }
                        else
                        {
                            //Play random turn
                        }
                        break;

                    case Difficulty.Easy:
                        if (r > 7)
                        {
                            //Will play perfect turn
                        }
                        else
                        {
                            //Will play random turn
                        }
                        break;
                }

            }

            
        }

        static int EasyComputerPick()
        {
            Random rnd = new Random();
            int p = rnd.Next(1, 10);
            return p;
        }
    }
}
