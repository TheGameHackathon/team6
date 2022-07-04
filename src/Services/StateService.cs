using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models.Dto;

namespace thegame.Services;

public class StateService
{
    public HashSet<VectorDto> stashes = new HashSet<VectorDto>();
    public Dictionary<VectorDto, CellDto> map = new Dictionary<VectorDto, CellDto>();
    public CellDto[] entities = new CellDto[0];
    private CellDto player = null;


    public StateService()
    {

    }

    public void LoadMap(CellDto[] entities)
    {
        map = entities.ToDictionary(cell => cell.Pos);
        this.entities = entities;
        player = entities.First(c => c.Type == "player");
    }

    public GameDto AGameDto(VectorDto movingObjectPosition)
    {
        var width = 15;
        var height = 15;

        player.Pos.X = movingObjectPosition.X;
        player.Pos.Y = movingObjectPosition.Y;

        return new GameDto(entities, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
    }
}