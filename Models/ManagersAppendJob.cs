namespace Company_CRM.Models
{
    public class ManagersAppendJob
    {
        public Contract Contract { get; set; }
        public List<Employee> Employees { get; set; }
        public Job JobToAppend { get; set; }
    }
}
