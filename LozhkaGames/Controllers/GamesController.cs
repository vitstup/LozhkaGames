using LozhkaGames.Interfaces;
using LozhkaGames.Models;
using LozhkaGames.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LozhkaGames.Controllers
{
    public class GamesController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly IGamesRepository gamesRepository;

        public GamesController(IUsersRepository usersRepository, IGamesRepository gamesRepository)
        {
            this.usersRepository = usersRepository;
            this.gamesRepository = gamesRepository;
        }

        public ViewResult Catalog()
        {
            GamesViewModel model = new GamesViewModel(gamesRepository.GetAllGames(), usersRepository.GetSessionUser());
            return View(model);
        }

        public IActionResult Details(string details) 
        {
            var games = gamesRepository.GetAllGames();
            List<Game> result = new List<Game>();

            if (details != null)
            {
                // Поиск по названию игры
                var byName = games.Where(game => game.gameName.IndexOf(details, StringComparison.OrdinalIgnoreCase) >= 0);

                // Поиск по жанру
                var byGenre = games.Where(game => game.GetGenres().Any(genre => genre.IndexOf(details, StringComparison.OrdinalIgnoreCase) >= 0));

                // Поиск по издателю
                var byPublisher = games.Where(game => game.publisher.IndexOf(details, StringComparison.OrdinalIgnoreCase) >= 0);

                // Объединение результатов
                result.AddRange(byName);
                result.AddRange(byGenre);
                result.AddRange(byPublisher);
            }

            SearchViewModel model = new SearchViewModel(result.ToArray(), usersRepository.GetSessionUser(), details);

            return View(model);
        }
    }
}
