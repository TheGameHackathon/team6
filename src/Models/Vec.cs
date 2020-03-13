namespace thegame.Models
{
    public class Vec
    {
        public Vec(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X, Y;

        public static Vec operator +(Vec first, Vec second)
        {
            return new Vec(first.X + second.X, first.Y + second.Y);
        }

        public static bool operator ==(Vec first, Vec second)
        {
            return first.X == second.X && first.Y == second.Y;
        }

        public static bool operator !=(Vec first, Vec second)
        {
            return !(first == second);
        }
    }
}