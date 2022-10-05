using CoreWebAPIDemo.Validators;

namespace CoreWebAPIDemo.Model
{
    public class MyTask : IMyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [PastDueDateValidator(ErrorMessage = "Due date cannot be a past date")] 
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IMyTask.Priorities Priority { get; set; }
        public IMyTask.Statuses Status { get; set; }
    }
}
