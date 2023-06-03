using LozhkaGames.Models;

namespace LozhkaGames.Interfaces
{
    public interface IUsersRepository
    {
        public User[] GetAllUsers();
        public User GetUserById(int id);

        public User GetSessionUser();

        public User GetUserByEmail(string email);
    }
}