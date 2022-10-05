using CoreWebAPIDemo.BL;
using CoreWebAPIDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPIDemo.Data
{
    public class SQLMyTaskContextRepo : IMyTaskContextRepo
    {
        private readonly MyTaskContext _context;
        public SQLMyTaskContextRepo(MyTaskContext context)
        {
            _context = context;
        }
        public async Task<MyTask> CreateMyTaskAsync(MyTask myTask, IValidators validators)
        {
            if (validators.ValidateMaxHighPriorityTasks(myTask))
                throw new ApplicationException("Max High Priority Task limit reached");

            _context.Tasks.Add(myTask);
            await _context.SaveChangesAsync();
            return myTask;
        }

        public IEnumerable<MyTask> GetMyTasks()
        {
            return _context.Tasks.ToList();
        }

        public async Task<IEnumerable<MyTask>> GetMyTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<MyTask> UpdateMyTaskAsync(MyTask task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
