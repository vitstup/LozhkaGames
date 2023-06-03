using LozhkaGames.Interfaces;
using LozhkaGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LozhkaGames.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly IKeysRepository keysRepository;

        private readonly ShopDbContext context;

        public PurchaseController(IUsersRepository usersRepository, IKeysRepository keysRepository, ShopDbContext context)
        {
            this.usersRepository = usersRepository;
            this.keysRepository = keysRepository;
            this.context = context;
        }

        public IActionResult PurchaseGame(int gameId, User user)
        {
            if (user == null) return Unauthorized("Ввойди в аккаунт для покупки");

            Debug.WriteLine("user email: " + user.email + ", user password: " + user.password);

            Debug.WriteLine("Game id: " + gameId.ToString());

            if (keysRepository.GetGameKeysAmount(gameId) == 0) return Unauthorized("Простите, но игры уже нет в наличии");

            SteamKey key = keysRepository.GetGameKey(gameId);
            if (key == null) return Unauthorized("Извините, по каким то непонятным причинам мы не смогли найти для вас ключ");

            string keyValue = key.keyValue;

            context.keys.Remove(key);
            context.SaveChanges();

            // maybe in future add this key, to user's account history

            return Ok(keyValue);
        }
    }
}