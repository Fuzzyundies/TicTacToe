using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ComputerTurn : Turn //Inherit from Turn
    {
        enum Difficulty //Enumeration is a list of possible values
        {
            Hard, Medium, Easy
        }

        public ComputerTurn(Difficulty HowHard)
        {
               
        }
    }
}
