using System.Drawing;

namespace thegame.Models
{
	public class GameField
	{
		public FieldCell[][] Cells { get; set; }
		public Point PlayerPoint { get; set; }
	}
}