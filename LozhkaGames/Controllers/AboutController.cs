using LozhkaGames.Interfaces;
using LozhkaGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace LozhkaGames.Controllers
{
    public class AboutController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public AboutController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ViewResult Index()
        {
            User model = usersRepository.GetSessionUser();
            return View(model);
        }
    }
}