using CoreWebAPIDemo.Model;

namespace CoreWebAPIDemo.BL
{
    public interface IValidators
    {
        bool ValidateMaxHighPriorityTasks(MyTask task);
    }
}
