using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models.Domain;
using ToDoAPI.Models.DTO;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : Controller
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GoalController(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }
        // GET: GoalController
        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            var goals = await _goalRepository.GetAllAsync();

            // return DTO goals
            //var goalsDTO = new List<Models.DTO.Goal>();
            //goals.ToList().ForEach(goal =>
            //{
            //    var goalDTO = new Models.DTO.Goal()
            //    {
            //        Id = goal.Id,
            //        Topic = goal.Topic,
            //        Description = goal.Description,
            //        CreatedDate = goal.CreatedDate,
            //        Period = goal.Period,
            //    };

            //    goalsDTO.Add(goalDTO);
            //});

            var goalsDTO = _mapper.Map<List<Models.DTO.Goal>>(goals);

            return Ok(goalsDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetGoalAsync")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetGoalAsync(int id)
        {
            var goal = await _goalRepository.GetAsync(id);

            if(goal == null)
            {
                return NotFound();
            }

            var goalDTO = _mapper.Map<Models.DTO.Goal>(goal);

            return Ok(goalDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddGoalRequest addGoalRequest)
        {
            //validate the request 
            //if (!ValidateAddGoalAsync(addGoalRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            //request(dto) to domain model
            var goal = new Models.Domain.Goal()
            {
                Id = addGoalRequest.Id,
                Topic = addGoalRequest.Topic,
                Description = addGoalRequest.Description,
                Period = addGoalRequest.Period
            };

            //pass details to repository
            goal = await _goalRepository.AddAsync(goal);

            //convert back to dto
            var goalDTO = new Models.DTO.Goal()
            {
                Id = goal.Id,
                Topic = goal.Topic,
                Description = goal.Description,
                Period = goal.Period
            };

            return CreatedAtAction(nameof(GetGoalAsync), new {id = goalDTO.Id}, goalDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteGoalAsync(int id)
        {
            //get region from database
            var goal = await _goalRepository.DeleteAsync(id);

            //if null notfound
            if (goal == null)
            {
                return NotFound();
            }

            //convert response back to dto
            var goalDTO = new Models.DTO.Goal
            {
                Id = goal.Id,
                Topic = goal.Topic,
                Description = goal.Description,
                Period = goal.Period
            };

            //return ok response
            return Ok(goalDTO);
        }


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateGoalAsync([FromRoute] int id,  [FromRoute]UpdateGoalRequest updateGoalRequest)
        {
            //validate the incoming request
            //if (!ValidateUpdateGoalAsync(updateGoalRequest))
            //{
            //    return BadRequest(ModelState);
            //}


            //convert dto to domain model
            var goal = new Models.Domain.Goal()
            {
                Topic = updateGoalRequest.Topic,
                Description = updateGoalRequest.Description,
                Period = updateGoalRequest.Period
            };

            //update goal using repository
            goal = await _goalRepository.UpdateAsync(id, goal);

            //if null then notfound
            if (goal == null)
            {
                return NotFound();
            }

            //convert domain back to dto
            var goalDTO = new Models.DTO.Goal
            {
                Id=goal.Id,
                Topic = goal.Topic,
                Description = goal.Description,
                Period = goal.Period
            };

            //return Ok response
            return Ok(goalDTO);
        }


        #region Private methods

        private bool ValidateAddGoalAsync(Models.DTO.AddGoalRequest addGoalRequest)
        {
            if (addGoalRequest == null)
            {
                ModelState.AddModelError(nameof(addGoalRequest),
                    $"Add Goal Data is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(addGoalRequest.Topic))
            {
                ModelState.AddModelError(nameof(addGoalRequest.Topic),
                   $"{nameof(addGoalRequest.Topic)} can not be null or empty or white space");
            }

            if (string.IsNullOrWhiteSpace(addGoalRequest.Description))
            {
                ModelState.AddModelError(nameof(addGoalRequest.Description),
                   $"{nameof(addGoalRequest.Description)} can not be null or empty or white space");
            }

            if (addGoalRequest.Period <= 0)
            {
                ModelState.AddModelError(nameof(addGoalRequest.Period),
                   $"{nameof(addGoalRequest.Period)} can not be less than or equal to zero.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;

        }

        private bool ValidateUpdateGoalAsync(Models.DTO.UpdateGoalRequest updateGoalRequest)
        {
            if (updateGoalRequest == null)
            {
                ModelState.AddModelError(nameof(updateGoalRequest),
                    $"Add Goal Data is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(updateGoalRequest.Topic))
            {
                ModelState.AddModelError(nameof(updateGoalRequest.Topic),
                   $"{nameof(updateGoalRequest.Topic)} can not be null or empty or white space");
            }

            if (string.IsNullOrWhiteSpace(updateGoalRequest.Description))
            {
                ModelState.AddModelError(nameof(updateGoalRequest.Description),
                   $"{nameof(updateGoalRequest.Description)} can not be null or empty or white space");
            }

            if (updateGoalRequest.Period <= 0)
            {
                ModelState.AddModelError(nameof(updateGoalRequest.Period),
                   $"{nameof(updateGoalRequest.Period)} can not be less than or equal to zero.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;

        }
        #endregion


    }
}
