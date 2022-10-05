using CoreWebAPIDemo.BL;
using CoreWebAPIDemo.Data;
using CoreWebAPIDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoreWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        private readonly IMyTaskContextRepo _context;
        public MyTaskController(IMyTaskContextRepo context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<IEnumerable<MyTask>> GetTasksAsync()
        {
            return await _context.GetMyTasksAsync();
        }

        [HttpPost]
        public async Task<MyTask> PostTaskAsync(MyTask task, IValidators validators)
        {
            return await _context.CreateMyTaskAsync(task, validators);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MyTask>> UpdateTaskAsync(int id, MyTask task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _context.UpdateMyTaskAsync(task);

            return task;
        }
    }
}
