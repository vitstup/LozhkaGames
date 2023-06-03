using LozhkaGames.Interfaces;
using LozhkaGames.Models;

namespace LozhkaGames.Repository
{
    public class KeysRepository : IKeysRepository
    {
        private readonly ShopDbContext context;

        public KeysRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public SteamKey GetGameKey(int gameId) => context.keys.FirstOrDefault(p => p.gameId == gameId);

        public int GetGameKeysAmount(int gameId) => context.keys.Count(p => p.gameId == gameId);
    }
}