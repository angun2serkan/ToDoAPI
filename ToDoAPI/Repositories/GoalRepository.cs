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

        public async Task<Goal> AddAsync(Goal goal)
        {
            await _databaseContext.AddAsync(goal);
            await _databaseContext.SaveChangesAsync();
            return goal;
        }

        public async Task<Goal> DeleteAsync(int id)
        {
            var goal = await _databaseContext.Goals.FirstOrDefaultAsync(x => x.Id == id);

            if (goal == null)
            {
                return null;
            }

            //delete the goal
            _databaseContext.Goals.Remove(goal);
            await _databaseContext.SaveChangesAsync();
            return goal;
        }

        public async Task<IEnumerable<Goal>> GetAllAsync()
        {
            return await _databaseContext.Goals.ToListAsync();
        }

        public async Task<Goal> GetAsync(int id)
        {
            return await _databaseContext.Goals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Goal> UpdateAsync(int id, Goal goal)
        {
            var existingGoal = await _databaseContext.Goals.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGoal == null)
            {
                return null;
            }
            existingGoal.Id = goal.Id;
            existingGoal.Topic = goal.Topic;
            existingGoal.Description = goal.Description;
            existingGoal.CreatedDate = goal.CreatedDate;
            existingGoal.Period = goal.Period;

            await _databaseContext.SaveChangesAsync();

            return existingGoal;
        }
    }
}
