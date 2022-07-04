namespace thegame.Models.Dto;

public class VectorDto
{
    public int X { get; set; }
    public int Y { get; set; }

    public VectorDto() {}

    public VectorDto(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override bool Equals(object vector)
    {
        if (vector != null && vector is VectorDto vectorDto)
        {
            return X == vectorDto.X && Y == vectorDto.Y;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return int.Parse($"{X}000000{Y}");
    }
}