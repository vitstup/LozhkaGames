using LozhkaGames.Interfaces;
using LozhkaGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace LozhkaGames.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUsersRepository usersRepository;

        private readonly ShopDbContext context;

        public AuthorizationController(IUsersRepository usersRepository, ShopDbContext context)
        {
            this.usersRepository = usersRepository;
            this.context = context;
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            if (string.IsNullOrWhiteSpace(newUser.email)) return Unauthorized("Введите email");
            var users = usersRepository.GetAllUsers();

            foreach(var user in users)
            {
                if (user.email.Trim().Equals(newUser.email.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return Unauthorized("email уже занят");
                }
            }

            if (string.IsNullOrWhiteSpace(newUser.password)) return Unauthorized("Введите пароль");
            if (newUser.password.Length < 8 || newUser.password.Length >= 24) return Unauthorized("Пароль некорректный");

            context.users.Add(newUser);
            context.SaveChanges();

            return Ok("Успешно");
        }

        [HttpPost]
        public IActionResult Login(User loginUser)
        {
            var user = usersRepository.GetUserByEmail(loginUser.email);
            if (user != null) 
            {
                if (user.password.Trim().Equals(loginUser.password.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    HttpContext.Session.SetString("UserId", user.id.ToString());
                    HttpContext.Session.SetString("UserLogin", user.email);
                    return Ok("Успешно");
                }
            }
            return Unauthorized("Неверный логин или пароль");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            var user = usersRepository.GetSessionUser();
            if (user == null) return Unauthorized("Вход не был произведен");
            else
            {
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("UserLogin");

                return Ok("Выполнен выход");
            }
        }
    }
}
