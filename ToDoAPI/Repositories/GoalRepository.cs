using Microsoft.EntityFrameworkCore;
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
         
        public async Task<IEnumerable<Goal>> GetAllAsync()
        {
            return await _databaseContext.Goals.ToListAsync();
        }
    }
}
