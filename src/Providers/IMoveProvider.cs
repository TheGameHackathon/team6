using thegame.Models;

namespace thegame.Providers
{
    public interface IMoveProvider
    {
        Vec GetMovement(UserInputForMovesPost input);
    }
}
