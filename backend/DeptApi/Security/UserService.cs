
using DeptApi.Models;
using System.Threading.Tasks;

namespace DeptApi.Security
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        public async Task<User> Authenticate(string username, string password)
        {
            // Hardcoded user for demonstration
            if (username == "admin" && password == "Admin@1234")
            {
                return await Task.FromResult(new User { Username = "admin" });
            }

            return null;
        }
    }
}
