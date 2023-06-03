using LozhkaGames.Models;

namespace LozhkaGames.Interfaces
{
    public interface IGamesRepository
    {
        public Game[] GetAllGames();

        public Game GetGameById(int id);
    }
}
