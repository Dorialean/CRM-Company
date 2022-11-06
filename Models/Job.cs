using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_CRM.Models
{
    public partial class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int JobId { get; set; }
        public int CreatorEmplId { get; set; }
        public int ExecutorEmplId { get; set; }
        public int? ContrId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        [Column("prior")]
        public string Prior { get; set; } = "low";
        public DateTime? Completed { get; set; }

        public virtual Contract? Contr { get; set; }
        public virtual Employee CreatorEmpl { get; set; } = null!;
        public virtual Employee ExecutorEmpl { get; set; } = null!;
    }

    enum Priority
    {
        low,
        medium,
        high
    }

}
