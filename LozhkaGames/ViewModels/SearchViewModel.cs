using LozhkaGames.Models;

namespace LozhkaGames.ViewModels
{
    public class SearchViewModel : GamesViewModel
    {
        public string request { get; private set; }
        public SearchViewModel(Game[] games, User user, string request) : base(games, user)
        {
            this.request = request;
        }
    }
}
