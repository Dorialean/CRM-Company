namespace Company_CRM.Models
{
    public class EmployeeReport
    {
        public int EmployeeId { get; set; }
        public int AllTasks { get; set; }
        public int InTimeCompleted { get; set; }
        public int NotInTimeCompleted { get; set; }
        public int FailedTasks { get; set; }
        public int InWorkTasks { get; set; }
    }
}
