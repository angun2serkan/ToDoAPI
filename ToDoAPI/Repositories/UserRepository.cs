using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoalDatabaseContext _goalDatabaseContext;
        public UserRepository(GoalDatabaseContext goalDatabaseContext)
        {
            _goalDatabaseContext = goalDatabaseContext;
        }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _goalDatabaseContext.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await _goalDatabaseContext.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await _goalDatabaseContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;

        }
    }
}
