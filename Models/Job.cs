using System;
using System.Collections.Generic;

namespace Company_CRM.Models
{
    public partial class Job
    {
        public int JobId { get; set; }
        public int CreatorEmplId { get; set; }
        public int ExecutorEmplId { get; set; }
        public int? ContrId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? Completed { get; set; }

        public virtual Contract? Contr { get; set; }
        public virtual Employee CreatorEmpl { get; set; } = null!;
        public virtual Employee ExecutorEmpl { get; set; } = null!;
    }
}
