using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoAppAPI.Application.Repositories;
using TodoAppAPI.Domain.Entities;
using TodoAppAPI.Domain.Entities.Common;

namespace TodoAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IDoneRepository _doneRepository;
        private readonly IInProgressRepository _inProgressRepository;
        private readonly IPendingRepository _pendingRepository;
        private readonly IRepository<BaseEntity> _repository;

        public TodosController(IDoneRepository doneRepository, IPendingRepository pendingRepository, IInProgressRepository inProgressRepository, IRepository<BaseEntity> repository)
        {
            _doneRepository = doneRepository;
            _pendingRepository = pendingRepository;
            _inProgressRepository = inProgressRepository;
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            var doneItems = _doneRepository.GetAll();
            var inProgressItems = _inProgressRepository.GetAll();
            var pendingItems = _pendingRepository.GetAll();
            var result = new
            {
                pendings = pendingItems.Select(item => new { id = item.Id, todo = item.Todo }).ToList(),
                inProgress = inProgressItems.Select(item => new { id = item.Id, todo = item.Todo }).ToList(),
                done = doneItems.Select(item => new { id = item.Id, todo = item.Todo }).ToList()
            };

            return Ok(result);
        }
        [HttpPost("todo")]
        public async Task<IActionResult> Add(Pending pending)
        {
           var result=  await _pendingRepository.AddAsync(pending);
            await _pendingRepository.SaveAsync();
            return Ok(result);

        }
        [HttpPut("update")]
        public async Task<IActionResult> Put(BaseEntity entity)
        {
            var result = _repository.Update(entity);
            
            return Ok(result);
        }




    }
}
