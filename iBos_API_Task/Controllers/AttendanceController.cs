using iBos_API_Task.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBos_API_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepo _attendanceRepository;

        public AttendanceController(IAttendanceRepo attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        // Define API endpoints for API04.

        //[HttpGet("API04/{employeeId}")]
        //public async Task<IActionResult> GetMonthlyAttendanceReport(int employeeId)
        //{
        //    // Implement logic to get the monthly attendance report for an employee.
        //    // Return the result as JSON.
        //}

        [HttpGet("API04")]
        public async Task<IActionResult> GetMonthlyAttendanceReport()
        {
            try
            {
                var monthlyReport = await _attendanceRepository.GetMonthlyAttendanceReportAsync();

                if (monthlyReport == null || !monthlyReport.Any())
                {
                    return NotFound("No monthly attendance report available.");
                }

                return Ok(monthlyReport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
