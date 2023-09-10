using System.ComponentModel.DataAnnotations;

namespace iBos_API_Task.Model.ViewModel
{
    public class EmployeeUpdateModel
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; }
    }

}
