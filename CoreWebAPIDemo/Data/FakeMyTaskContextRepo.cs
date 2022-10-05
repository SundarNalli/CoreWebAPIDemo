using CoreWebAPIDemo.BL;
using CoreWebAPIDemo.Model;

namespace CoreWebAPIDemo.Data
{
    public class FakeMyTaskContextRepo : IMyTaskContextRepo
    {
        private List<MyTask> tasks = new List<MyTask>
        {
            new MyTask { Id = 1, Name = "Task 1", Description = "Task 1 Description",
                DueDate = new System.DateTime().AddDays(10),
                 StartDate = new System.DateTime().AddDays(10),
                 EndDate = new System.DateTime().AddDays(30),
                 Priority = IMyTask.Priorities.Medium,
                 Status = IMyTask.Statuses.New
                 },
            new MyTask { Id = 2, Name = "Task 2", Description = "Task 2 Description",
                DueDate = new System.DateTime().AddDays(20),
                 StartDate = new System.DateTime().AddDays(10),
                 EndDate = new System.DateTime().AddDays(30),
                  Priority = IMyTask.Priorities.Medium,
                 Status = IMyTask.Statuses.New
                 }
        };

        public Task<MyTask> CreateMyTaskAsync(MyTask task, IValidators validators)
        {
            tasks.Add(task);
            return Task.FromResult(task);
        }

        public IEnumerable<MyTask> GetMyTasks()
        {
            return tasks;
        }

        public Task<IEnumerable<MyTask>> GetMyTasksAsync()
        {
            return Task.FromResult<IEnumerable<MyTask>>(tasks);
        }

        public Task<MyTask> UpdateMyTaskAsync(MyTask task)
        {
            var priorTask = tasks.Find(x => x.Id == task.Id);
            tasks.Remove(priorTask);
            tasks.Add(task);
            return Task.FromResult(task);
        }
    }
}
