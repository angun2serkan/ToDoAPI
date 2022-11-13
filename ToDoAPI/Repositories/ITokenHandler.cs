using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
