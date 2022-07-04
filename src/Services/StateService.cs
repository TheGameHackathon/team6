using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using thegame.Models.Dto;

namespace thegame.Services;

public class GameState
{
    public HashSet<VectorDto> stashes = new HashSet<VectorDto>();
    public Dictionary<VectorDto, CellDto> map = new Dictionary<VectorDto, CellDto>();
    public CellDto[] entities = new CellDto[0];
    public CellDto[] Entities => entities.Select(c => c.Type == "box" ? GetUpdatedBox(c) : c).ToArray();
    public CellDto player = null;
    public Guid gameId = Guid.Empty;


    public GameState(Guid gameId)
    {
        this.gameId = gameId;
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
        player.Pos.X = movingObjectPosition.X;
        player.Pos.Y = movingObjectPosition.Y;

        return AGameDto();
    }

    public GameDto AGameDto()
    {
        var width = 15;
        var height = 15;

        return new GameDto(Entities, true, true, width, height, gameId, CheckWin(), 0);
    }

    private bool CheckWin()
    {
        return stashes.All(pos => map.ContainsKey(pos) && map[pos].Type == "box");
    }

    private CellDto GetUpdatedBox(CellDto box)
    {
        var resBox = new CellDto(box.Id, box.Pos, box.Type, box.Content, box.ZIndex);

        if (stashes.Contains(box.Pos) && box.Type == "box")
        {
            resBox.Type = "boxOnTarget";
        }

        return resBox;
    }
}