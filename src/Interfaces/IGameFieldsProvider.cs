using thegame.Models;

namespace thegame.Interfaces
{
	public interface IGameFieldsProvider
	{
		GameField[] LoadFields();
	}
}