using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_CRM.Models
{
    public partial class Contract
    {
        public Contract()
        {
            AvailableClients = new HashSet<AvailableClient>();
            Jobs = new HashSet<Job>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContractId { get; set; }
        public int ClientId { get; set; }
        public int SneakerId { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime? Deadline { get; set; }

        public virtual AvailableClient Client { get; set; } = null!;
        public virtual Sneaker Sneaker { get; set; } = null!;
        public virtual ICollection<AvailableClient> AvailableClients { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
