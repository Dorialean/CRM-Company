using System;
using System.Collections.Generic;

namespace Company_CRM.Models
{
    public partial class AvailableClient
    {
        public AvailableClient()
        {
            Contracts = new HashSet<Contract>();
        }

        public int ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string OrganisationName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? ContractId { get; set; }

        public virtual Contract? Contract { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
