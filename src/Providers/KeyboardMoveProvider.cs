using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;
using thegame.wwwroot.Enums;

namespace thegame.Providers
{
    public class KeyboardMoveProvider : IMoveProvider
    {
        public Vec GetMovement(UserInputForMovesPost input)
        {
            switch ((KeyPress)input.KeyPressed)
            {
                case KeyPress.KEY_DOWN:
                    return new Vec(0, 1);
                case KeyPress.KEY_LEFT:
                    return  new Vec(-1, 0);
                case KeyPress.KEY_RIGHT:
                    return  new Vec(1, 0);
                case KeyPress.KEY_UP:
                    return new Vec(0, -1);
            }

            return new Vec(0, 0);
        }
    }
}
