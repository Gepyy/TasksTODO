namespace TasksTODO.Models
{
    public class TasksModel
    {
        public int TaskID { get; set; }
        public string TaskTheme { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool CheckComplete { get; set; }
    }
}
