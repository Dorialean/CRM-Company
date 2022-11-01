namespace Company_CRM.Models
{
    public class ManagersInfo
    {
        public List<Contract> Contracts { get; set; }
        public List<Job> Jobs { get; set; }
        public List<AvailableClient> AvailableClients { get; set; }
        public List<PotentialClient> PotentialClients { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Sneaker> Sneakers { get; set; }
    }
}
