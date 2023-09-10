using iBos_API_Task.Model.ViewModel;
using iBos_API_Task.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBos_API_Task.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IAttendanceRepo _attendanceRepo;

        public EmployeeController(IEmployeeRepo employeeRepository,
                                  IAttendanceRepo attendanceRepo)
        {
            _employeeRepo = employeeRepository;
            _attendanceRepo = attendanceRepo;
        }

        [HttpPost("API01")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateModel model)
        {
            try
            {
                var existingEmployee = await _employeeRepo.GetByIdAsync(model.EmployeeId);
                if (existingEmployee == null)
                {
                    return NotFound("Employee not found");
                }

                // Check for duplicate employee code
                if (await _employeeRepo.IsEmployeeCodeDuplicateAsync(model.EmployeeCode, model.EmployeeId))
                {
                    return BadRequest("Employee code is already in use.");
                }

                // Update the employee's name and code
                existingEmployee.EmployeeName = model.EmployeeName;
                existingEmployee.EmployeeCode = model.EmployeeCode;

                // Save changes to the database
                if (await _employeeRepo.UpdateAsync(existingEmployee))
                {
                    return Ok("Employee updated successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to update employee.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("API02")]
        public async Task<IActionResult> GetEmployeeWithThirdHighestSalary()
        {
            try
            {
                var employee = await _employeeRepo.GetEmployeeWithThirdHighestSalaryAsync();

                if (employee == null)
                {
                    return NotFound("No employee found with the third highest salary.");
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("API03")]
        public async Task<IActionResult> GetEmployeesWithNoAbsentRecord()
        {
            try
            {
                var employees = await _employeeRepo.GetEmployeesWithNoAbsentRecordAsync();

                if (employees == null || !employees.Any())
                {
                    return NotFound("No employees found with no absent records.");
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        


        [HttpGet("API05/{employeeId}")]
        public async Task<IActionResult> GetHierarchy(int employeeId)
        {
            try
            {
                var hierarchy = await _employeeRepo.GetHierarchyAsync(employeeId);

                if (hierarchy == null || !hierarchy.Any())
                {
                    return NotFound("No hierarchy found for the specified employee.");
                }

                return Ok(hierarchy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
