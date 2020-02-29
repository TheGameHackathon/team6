using System.Collections.Generic;
using System.Drawing;
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
			var gameFields = new List<GameField>();
			var gameField = new GameField();
			var cells = new List<FieldCell[]>();
			foreach (var line in lines)
			{
				if (string.IsNullOrEmpty(line))
				{
					gameField.Cells = cells.ToArray();
					gameFields.Add(gameField);
					gameField = new GameField();
					continue;
				}
				// var cellsLine = ParsLine(line);
			}
			return new GameField[0];
		}

	}
}