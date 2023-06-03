using LozhkaGames.Models;

namespace LozhkaGames.ViewModels
{
    public class FullGameViewModel : GameViewModel
    {
        public int keysAmount { get; private set; }

        public FullGameViewModel(Game game, User user, int keysAmount) : base(game, user)
        {
            this.keysAmount = keysAmount;
        }
    }
}