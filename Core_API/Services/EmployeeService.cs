using Core_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Services
{
    public class EmployeeService : IService<Employee, int>
    {
        private readonly CompanyContext _context;
        /// <summary>
        /// Injected the CompanyContext
        /// </summary>
        /// <param name="context"></param>
        public EmployeeService(CompanyContext context)
        {
            _context = context;
        }

        async Task<Employee> IService<Employee, int>.CreateAsync(Employee entity)
        {
            var result = await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        async Task IService<Employee, int>.DeleteAsync(int id)
        { 
            var empToDelete = await _context.Employees.FindAsync(id);     
            if(empToDelete != null)
            {
                _context.Employees.Remove(empToDelete);
                await _context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Employee>> IService<Employee, int>.GetAsync()
        {
           var emps =  await _context.Employees.ToListAsync();
            return emps;
                         
        }

        async Task<Employee> IService<Employee, int>.GetAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        async Task<Employee> IService<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            var empToUpdate = await _context.Employees.FindAsync(id);
            if (empToUpdate != null) 
            {
                empToUpdate.EmpName = entity.EmpName;
                empToUpdate.Designation = entity.Designation;
                empToUpdate.Salary = entity.Salary;
                empToUpdate.DeptNo = entity.DeptNo;
                await _context.SaveChangesAsync();
                return empToUpdate;
            }
            return null;
        }
    }
}
