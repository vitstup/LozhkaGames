using LozhkaGames.Models;

namespace LozhkaGames.ViewModels
{
    public class GamesViewModel
    {
        public Game[] games { get; private set; }

        public User user { get; private set; }

        public GamesViewModel(Game[] games, User user)
        {
            this.games = games;
            this.user = user;
        }
    }
}