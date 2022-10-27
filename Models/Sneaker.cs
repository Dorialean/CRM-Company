using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_CRM.Models
{
    public partial class Sneaker
    {
        public Sneaker()
        {
            Contracts = new HashSet<Contract>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SneakerId { get; set; }
        public string? Model { get; set; }
        public decimal? Weight { get; set; }
        public string? Size { get; set; }
        public DateTime Arrived { get; set; }
        public DateTime? Leaved { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
