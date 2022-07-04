using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        map = entities.Where(cell => cell.Type != "target").ToDictionary(cell => cell.Pos);
        this.entities = entities;
        stashes = entities.Where(cell => cell.Type == "target").Select(cell => cell.Pos).ToHashSet();
        player = entities.First(c => c.Type == "player");
    }

    public GameDto AGameDto(VectorDto movingObjectPosition)
    {
        var width = 10;
        var height = 8;

        player.Pos.X = movingObjectPosition.X;
        player.Pos.Y = movingObjectPosition.Y;

        return new GameDto(entities, true, true, width, height, Guid.Empty, CheckWin(), movingObjectPosition.Y);
    }

    public bool CheckWin()
    {
        return stashes.All(pos => map.ContainsKey(pos) && map[pos].Type == "box");
    }
}