using ToDoAPI.Data;
using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly GoalDatabaseContext _databaseContext;
        public GoalRepository(GoalDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Goal> GetAll()
        {
            return _databaseContext.Goals.ToList();
        }

    }
}
