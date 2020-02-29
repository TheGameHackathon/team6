using System.Collections.Generic;
using thegame.Interfaces;

namespace thegame.Models
{
	public class GameFieldsRepository: IGameFieldsRepository
	{
		private readonly List<GameField> gameFields;

		public GameFieldsRepository()
		{
			
		}
		
		public GameField GetField(int fieldIndex)
		{
			throw new System.NotImplementedException();
		}

		public void AddNewField(GameField field)
		{
			throw new System.NotImplementedException();
		}
	}
}