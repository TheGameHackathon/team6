using System.Collections.Generic;
using System.IO;
using System.Linq;
using thegame.Interfaces;

namespace thegame.Models
{
	public class GameFieldsProvider: IGameFieldsProvider
	{
		public GameField[] LoadFields()
		{
			var lines = File.ReadLines("GameFields.txt");
			lines.Select(line =>
			{
				var gameField = new GameField
				{
					
				};
				return gameField;
			});
		}
	}
}