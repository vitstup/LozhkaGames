using LozhkaGames.Interfaces;
using LozhkaGames.Models;

namespace LozhkaGames.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private readonly ShopDbContext context;

        public GamesRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public Game[] GetAllGames()
        {
            return context.games.ToArray();
        }

        public Game GetGameById(int id) => context.games.FirstOrDefault(p => p.id == id);
    }
}
