﻿using AutoMapper;
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
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddGoalRequest addGoalRequest)
        {
            //request(dto) to domain model
            var goal = new Models.Domain.Goal()
            {
                Id = addGoalRequest.Id,
                Topic = addGoalRequest.Topic,
                Description = addGoalRequest.Description,
                CreatedDate = addGoalRequest.CreatedDate,
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
                CreatedDate = goal.CreatedDate,
                Period = goal.Period
            };

            return CreatedAtAction(nameof(GetGoalAsync), new {id = goalDTO.Id}, goalDTO);
        }

        
    }
}
