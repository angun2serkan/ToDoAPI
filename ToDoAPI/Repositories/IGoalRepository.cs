using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public interface IGoalRepository
    {
        Task <IEnumerable<Goal>> GetAllAsync();
        Task<Goal> GetAsync(int id);
        Task<Goal> AddAsync(Goal goal);
        Task<Goal> DeleteAsync(int id);
    }
}
