using LozhkaGames.Models;

namespace LozhkaGames.Interfaces
{
    public interface IKeysRepository
    {
        public SteamKey GetGameKey(int gameId);

        public int GetGameKeysAmount(int gameId);
    }
}