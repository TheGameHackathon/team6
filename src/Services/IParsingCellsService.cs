using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Services
{
    public interface IParsingCellsService
    {
        CellDto[] Parse(string[] stringCells);
    }
}
