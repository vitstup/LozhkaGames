using LozhkaGames.Interfaces;
using LozhkaGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace LozhkaGames.Controllers
{
    public class FAQController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public FAQController(IUsersRepository usersRepository)
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