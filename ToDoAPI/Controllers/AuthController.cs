using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            //validate the incoming request

            //check if user is authenticated
            // check username and password

            var isAuthenticated = await _userRepository.AuthenticateAsync(
                loginRequest.Username, loginRequest.Password);

            if (isAuthenticated)
            {

                // generate a jwt token
            }

            return BadRequest("Username or password is incorrect.");
        }
    }
}
