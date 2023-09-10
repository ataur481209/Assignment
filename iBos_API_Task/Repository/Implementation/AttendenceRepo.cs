using iBos_API_Task.Model;
using iBos_API_Task.Model.ViewModel;
using iBos_API_Task.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace iBos_API_Task.Repository.Implementation
{
    public class AttendenceRepo : IAttendanceRepo
    {
        private readonly iBosDbContext _dbContext;

        public AttendenceRepo(iBosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<IEnumerable<EmployeeAttendance>> GetAttendanceByEmployeeIdAsync(int employeeId)
        //{
        //    return await _dbContext.EmployeeAttendances
        //        .Where(a => a.EmployeeId == employeeId)
        //        .ToListAsync();
        //}

        //public async Task<EmployeeAttendance> AddAsync(EmployeeAttendance attendance)
        //{
        //    _dbContext.EmployeeAttendances.Add(attendance);
        //    await _dbContext.SaveChangesAsync();
        //    return attendance;
        //}

        public async Task<IEnumerable<MonthlyAttendanceReport>> GetMonthlyAttendanceReportAsync()
        {
            var monthlyReport = await _dbContext.EmployeeAttendances
                .GroupBy(a => new { a.Employee.EmployeeName, a.AttendanceDate.Month })
                .Select(g => new MonthlyAttendanceReport
                {
                    EmployeeName = g.Key.EmployeeName,
                    MonthName = g.Key.Month,
                    PayableSalary = g.Max(a => a.Employee.EmployeeSalary), // Use the employee's salary directly
                    TotalPresent = g.Sum(a => a.IsPresent ? 1 : 0),
                    TotalAbsent = g.Sum(a => a.IsAbsent ? 1 : 0),
                    TotalOffday = g.Sum(a => a.IsOffday ? 1 : 0)
                })
                .ToListAsync();

            return monthlyReport;
        }

    }
}
