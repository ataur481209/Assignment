using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iBos_API_Task.Model
{
    public class EmployeeAttendance
    {
        [Key]
        public int EmployeeAttendanceId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required, Column(TypeName = "date"),
        Display(Name = "Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        [Required]
        public bool IsAbsent { get; set; }

        [Required]
        public bool IsOffday { get; set; }

        // Navigation
        public virtual Employee Employee { get; set; } = default!;
    }
}
