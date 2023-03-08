using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UsersRepository
    {
        private const string CacheKey = "users.cache";

        /*
         * As a POC let's mimic the data Store using a memory cache.
         * In a real project, we would use a DataBase.
         */
        private readonly IMemoryCache _cache;

        public UsersRepository(IMemoryCache cache)
        {
            _cache = cache;
        }


        public IEnumerable<User> GetUsers()
        {
            return _cache.TryGetValue(CacheKey, out IEnumerable<User> users) ? users : Array.Empty<User>();
        }

        public User GetUserById(Guid id)
        {
            var users = GetUsers();

            return users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            var users = GetUsers();

            users = users.Append(user);

            _cache.Set(CacheKey, users, TimeSpan.FromDays(1));
        }

        public void UpdateUser(User user)
        {
            var users = GetUsers().ToArray();

            int index = users.Where(u => u.Id == user.Id).Select((u, i) => i).FirstOrDefault();

            users[index] = user;


            _cache.Set(CacheKey, users, TimeSpan.FromDays(1));
        }

        public void DeleteUser(Guid id)
        {
            var users = GetUsers();

            users = users.Where(u => u.Id != id);

            _cache.Set(CacheKey, users, TimeSpan.FromDays(1));
        }
    }
}
