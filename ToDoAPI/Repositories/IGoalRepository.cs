using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public interface IGoalRepository
    {
        Task <IEnumerable<Goal>> GetAllAsync();
        Task<Goal> GetAsync(int id);
    }
}
