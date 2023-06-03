using LozhkaGames.Models;

namespace LozhkaGames.ViewModels
{
    public class GameViewModel
    {
        public Game game { get; private set; }
        public User user { get; private set; }

        public GameViewModel(Game game, User user)
        {
            this.game = game;
            this.user = user;
        }
    }
}
