using CoreWebAPIDemo.Data;
using CoreWebAPIDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPIDemo.BL
{
    public class Validators : IValidators
    {
        private readonly IMyTaskContextRepo _context;
        public Validators(IMyTaskContextRepo context)
        {
            _context = context;
        }

        public bool ValidateMaxHighPriorityTasks(MyTask task)
        {
            var result = from t in _context.GetMyTasks()
                         where t.Status != IMyTask.Statuses.Finished
                         group t by new { t.Priority, t.DueDate } into taskGroup
                         where taskGroup.Count() > 1
                         select taskGroup;

            return result.Any();
        }
    }
}
