using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Providers
{
    public interface IMoveProvider
    {
        Vec GetMovement(UserInputForMovesPost input);
    }
}
