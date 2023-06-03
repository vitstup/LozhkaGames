using LozhkaGames.Interfaces;
using LozhkaGames.Models;

namespace LozhkaGames.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ShopDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsersRepository(ShopDbContext context, IHttpContextAccessor httpContextAccessor) 
        { 
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public User[] GetAllUsers()
        {
            return context.users.ToArray();
        }

        public User GetUserById(int id) => context.users.FirstOrDefault(p => p.id == id);

        public User GetSessionUser()
        {
            string userId = httpContextAccessor.HttpContext.Session.GetString("UserId");
            string userLogin = httpContextAccessor.HttpContext.Session.GetString("UserLogin");

            if (userId != null && userLogin != null)
            {
                // Создание и возврат модели пользователя
                return new User { id = int.Parse(userId), email = userLogin };
            }

            return null;
        }

        public User GetUserByEmail(string email) => context.users.FirstOrDefault(p => p.email.Trim().Equals(email.Trim()));
    }
}