using LozhkaGames.Interfaces;
using LozhkaGames.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LozhkaGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly IGamesRepository gamesRepository;
        private readonly IKeysRepository keysRepository;

        public HomeController(IUsersRepository usersRepository, IGamesRepository gamesRepository, IKeysRepository keysRepository)
        {
            this.usersRepository = usersRepository;
            this.gamesRepository = gamesRepository;
            this.keysRepository = keysRepository;
        }

        public IActionResult Index()
        {
            GamesViewModel model = new GamesViewModel(gamesRepository.GetAllGames(), usersRepository.GetSessionUser());
            return View(model);
        }

        public IActionResult Game(int id)
        {
            FullGameViewModel model = new FullGameViewModel(gamesRepository.GetGameById(id), usersRepository.GetSessionUser(), keysRepository.GetGameKeysAmount(id));
            return View(model);
        }
    }
}