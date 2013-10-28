using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    /// <summary>
    /// Simple screen class that is called when we want to close the program
    /// </summary>
    public class ExitScreen : GameScreen
    {
        /// <summary>
        /// Only function, returns a true value since we want to close the program
        /// </summary>
        /// <returns></returns>
        public override bool Exit()
        {
            return true;
        }
    }
}
