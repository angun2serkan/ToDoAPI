using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public interface IGoalRepository
    {
        IEnumerable<Goal> GetAll();
    }
}
