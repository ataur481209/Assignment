using iBos_API_Task.Model;

namespace iBos_API_Task.Repository.Interface
{
    public interface IEmployeeRepo
    {
        Task<Employee> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Employee employee);
        //Task<IEnumerable<Employee>> GetAllAsync();
        //Task<Employee> AddAsync(Employee employee);
        //task<bool> updateasync(employee employee);
        //Task<bool> DeleteAsync(int id);

        Task<bool> IsEmployeeCodeDuplicateAsync(string employeeCode, int employeeId);
        Task<Employee> GetEmployeeWithThirdHighestSalaryAsync();
        Task<IEnumerable<Employee>> GetEmployeesWithNoAbsentRecordAsync();
        Task<IEnumerable<Employee>> GetHierarchyAsync(int employeeId);

    }


}
