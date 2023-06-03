using LozhkaGames.Models;

namespace LozhkaGames
{
    public class SteamKeysGenerator
    {
        private readonly ShopDbContext context;

        public SteamKeysGenerator(ShopDbContext context)
        {
            this.context = context;
        }

        public void GenerateKeysForAllGames(int keysAmount)
        {
            var games = context.games.ToArray();
            foreach (var game in games)
            {
                GenerateKeysForGame(game.id, keysAmount);
            }
        }

        public void GenerateKeysForGame(int gameId, int keysAmount)
        {
            for (int i = 0; i < keysAmount; i++)
            {
                context.keys.Add(new SteamKey() { gameId = gameId, keyValue = GenerateKey() });
            }
            context.SaveChanges();
        }

        private string GenerateKey()
        {
            Random random = new Random();
            string key = "";

            for (int i = 0; i < 15; i++)
            {
                char randomChar = (char)random.Next('A', 'Z' + 1);
                if (random.Next(2) == 0)
                {
                    randomChar = Char.ToLower(randomChar);
                }
                key += randomChar;

                if ((i + 1) % 5 == 0 && i != 14)
                {
                    key += "-";
                }
            }

            return key;
        }
    }
}
