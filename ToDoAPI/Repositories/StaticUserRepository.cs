using ToDoAPI.Models.Domain;

namespace ToDoAPI.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            new User()
            {
                FirstName = "Serkan", LastName="Angün", EmailAdress="angun.serkan2@gmail.com",
                Id = 1, Username="player2srkn", Password="03041996", Roles=new List<string>{"reader"}
            },

            new User()
            {
                FirstName = "Ufuk", LastName="Yarışan", EmailAdress="vmhdvm@gmail.com",
                Id = 2, Username="vmhdvm", Password="07091996", Roles=new List<string>{"reader", "writer"}
            },
        };
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var user =Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
