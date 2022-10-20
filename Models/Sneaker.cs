using System;
using System.Collections.Generic;

namespace Company_CRM.Models
{
    public partial class Sneaker
    {
        public Sneaker()
        {
            Contracts = new HashSet<Contract>();
        }

        public int SneakerId { get; set; }
        public string? Model { get; set; }
        public decimal? Weight { get; set; }
        public string? Size { get; set; }
        public DateTime Arrived { get; set; }
        public DateTime? Leaved { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
