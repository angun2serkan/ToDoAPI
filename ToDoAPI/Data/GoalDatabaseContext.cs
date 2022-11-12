using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models.Domain;

namespace ToDoAPI.Data
{
    public class GoalDatabaseContext : DbContext
    {
        public GoalDatabaseContext(DbContextOptions<GoalDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Goal> Goals { get; set; }
    }
}
