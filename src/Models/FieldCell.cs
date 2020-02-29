namespace thegame.Models
{
	public class FieldCell
	{
		public FieldCell(BackgroundObject type, ForegroundObject obj)
		{
			Type = type;
			Object = obj;
		}

		public BackgroundObject Type { get; set; }
		public ForegroundObject Object { get; set; }
	}
}