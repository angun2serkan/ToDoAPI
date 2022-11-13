using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);

    }
}
