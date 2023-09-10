using iBos_API_Task.Model;
using iBos_API_Task.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace iBos_API_Task.Repository.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly iBosDbContext _dbContext;

        public EmployeeRepo(iBosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        //public async Task<IEnumerable<Employee>> GetAllAsync()
        //{
        //    return await _dbContext.Employees.ToListAsync();
        //}

        //public async Task<Employee> AddAsync(Employee employee)
        //{
        //    _dbContext.Employees.Add(employee);
        //    await _dbContext.SaveChangesAsync();
        //    return employee;
        //}

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var employee = await _dbContext.Employees.FindAsync(id);
        //    if (employee == null)
        //        return false;

        //    _dbContext.Employees.Remove(employee);
        //    return await _dbContext.SaveChangesAsync() > 0;
        //}

        public async Task<bool> IsEmployeeCodeDuplicateAsync(string employeeCode, int employeeId)
        {
            return await _dbContext.Employees
                .AnyAsync(e => e.EmployeeCode == employeeCode && e.EmployeeId != employeeId);
        }


        public async Task<Employee> GetEmployeeWithThirdHighestSalaryAsync()
        {
            return await _dbContext.Employees
                .OrderByDescending(e => e.EmployeeSalary)
                .Skip(2)
                .Take(1)
                .SingleOrDefaultAsync();
        }


        public async Task<IEnumerable<Employee>> GetEmployeesWithNoAbsentRecordAsync()
        {
            var employeeIdsWithAbsences = await _dbContext.EmployeeAttendances
                .Where(a => a.IsAbsent)
                .Select(a => a.EmployeeId)
                .ToListAsync();

            var employeesWithNoAbsences = await _dbContext.Employees
                .Where(e => !employeeIdsWithAbsences.Contains(e.EmployeeId))
                .OrderByDescending(e => e.EmployeeSalary) // Order by salary max to min
                .ToListAsync();

            return employeesWithNoAbsences;
        }

        //public async Task<IEnumerable<Employee>> GetHierarchyAsync(int employeeId)
        //{
        //    var hierarchy = new List<Employee>();
        //    var currentEmployee = await _dbContext.Employees.FindAsync(employeeId);

        //    // Traverse up the hierarchy to the top supervisor
        //    while (currentEmployee != null)
        //    {
        //        hierarchy.Add(currentEmployee);
        //        currentEmployee = await _dbContext.Employees.FindAsync(currentEmployee.SupervisorId);
        //    }

        //    hierarchy.Reverse(); // Reverse the hierarchy to start with Selim Reja -- not working
        //    hierarchy = hierarchy.OrderByDescending(e => e.EmployeeId).ToList(); // Sort by EmployeeId descending

        //    return hierarchy;
        //}



        public async Task<IEnumerable<Employee>> GetHierarchyAsync(int employeeId)
        {
            var hierarchy = new List<Employee>();
            var currentEmployee = await _dbContext.Employees.FindAsync(employeeId);

            while (currentEmployee != null)
            {
                hierarchy.Add(currentEmployee);

                // Check for a circular reference or infinite loop
                if (hierarchy.Any(e => e.EmployeeId == currentEmployee.SupervisorId))
                {
                    Console.WriteLine("Circular reference detected.");
                    break;
                }

                currentEmployee = await _dbContext.Employees.FindAsync(currentEmployee.SupervisorId);
            }

            hierarchy.Reverse();
            hierarchy = hierarchy.OrderByDescending(e => e.EmployeeId).ToList();

            return hierarchy;
        }



    }
}
