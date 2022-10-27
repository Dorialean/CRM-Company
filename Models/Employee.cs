using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_CRM.Models
{
    public partial class Employee
    {
        public Employee()
        {
            JobCreatorEmpls = new HashSet<Job>();
            JobExecutorEmpls = new HashSet<Job>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? FatherName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? FactoryRole { get; set; }
        public string? Login { get; set; }
        public byte[]? Password { get; set; }
        public string? SaltPass { get; set; }

        public virtual ICollection<Job> JobCreatorEmpls { get; set; }
        public virtual ICollection<Job> JobExecutorEmpls { get; set; }
        }
}
