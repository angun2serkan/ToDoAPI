using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models.Domain;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : Controller
    {
        private readonly IGoalRepository _goalRepository;
        public GoalController(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }
        // GET: GoalController
        [HttpGet]
        public IActionResult GetAllGoals()
        {
            var goals = _goalRepository.GetAll();
            return Ok(goals);
        }

        
    }
}
