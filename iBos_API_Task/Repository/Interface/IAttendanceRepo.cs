using iBos_API_Task.Model.ViewModel;

namespace iBos_API_Task.Repository.Interface
{
    public interface IAttendanceRepo
    {
        //Task<IEnumerable<EmployeeAttendance>> GetAttendanceByEmployeeIdAsync(int employeeId);
        //Task<EmployeeAttendance> AddAsync(EmployeeAttendance attendance);
        Task<IEnumerable<MonthlyAttendanceReport>> GetMonthlyAttendanceReportAsync();
    }
}
