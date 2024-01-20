namespace Tasks.Business
{
    //create model for Task's Data Transfer Objects
    public class TasksDTO
    {
        public int TaskID { get; set; }
        public string TaskTheme { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool CheckComplete { get; set; }
    }
}
