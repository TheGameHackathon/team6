using thegame.Models;

namespace thegame.Interfaces
{
	public interface IGameFieldsRepository
	{
		GameField GetField(int fieldIndex);
		void AddNewField(GameField field);
	}
}