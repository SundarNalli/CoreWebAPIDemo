using CoreWebAPIDemo.BL;
using CoreWebAPIDemo.Model;

namespace CoreWebAPIDemo.Data
{
    public interface IMyTaskContextRepo
    {
        Task<MyTask> CreateMyTaskAsync(MyTask task, IValidators validators);
        Task<IEnumerable<MyTask>> GetMyTasksAsync();
        IEnumerable<MyTask> GetMyTasks();
        Task<MyTask> UpdateMyTaskAsync(MyTask task);


    }
}
