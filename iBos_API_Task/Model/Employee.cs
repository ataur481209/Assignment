using System.ComponentModel.DataAnnotations;

namespace iBos_API_Task.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; } = default!;

        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = default!;

        [Required]
        public decimal EmployeeSalary { get; set; }

        [Required]
        public int SupervisorId { get; set; } //regular field, not FK

        // Navigation
        public virtual ICollection<EmployeeAttendance> EmployeeAttendances { get; set; } = default!;
    }
}
