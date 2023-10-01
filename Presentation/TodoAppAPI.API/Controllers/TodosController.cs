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

        public TodosController(IDoneRepository doneRepository, IPendingRepository pendingRepository, IInProgressRepository inProgressRepository)
        {
            _doneRepository = doneRepository;
            _pendingRepository = pendingRepository;
            _inProgressRepository = inProgressRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            await _doneRepository.SaveAsync();
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
        [HttpPost("done")]
        public async Task<IActionResult> Add(Done done)
        {
            await _doneRepository.AddAsync(done);
            await _doneRepository.SaveAsync();
            return Ok("Todo Başarılı Eklendi");

        }
        
        

    }
}
