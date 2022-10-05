namespace CoreWebAPIDemo.Model
{
    public interface IMyTask
    {
        enum Priorities
        {

            Low,
            Medium,
            High
        }
        enum Statuses
        {
            New,
            InProgress,
            Finished
        }
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime DueDate { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        Priorities Priority { get; set; }
        Statuses Status { get; set; }
    }
}
