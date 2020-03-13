using System;
using System.Collections.Generic;
using System.Text;

namespace thegame.Providers
{
    public interface IGameDataLoader
    {
        string[] Load(int level);
        int GetLevelsAmount();
    }
}
