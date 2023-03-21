using Core_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Services
{
    public class DepartmentService : IService<Department, int>
    {
        private readonly CompanyContext _context;
        /// <summary>
        /// Injected the CompanyContext
        /// </summary>
        /// <param name="context"></param>
        public DepartmentService(CompanyContext context)
        {
            _context = context;
        }

        async Task<Department> IService<Department, int>.CreateAsync(Department entity)
        {
            var result = await _context.Departments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        async Task IService<Department, int>.DeleteAsync(int id)
        { 
            var deptToDelete = await _context.Departments.FindAsync(id);     
            if(deptToDelete != null)
            {
                _context.Departments.Remove(deptToDelete);
                await _context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
        {
           var depts =  await _context.Departments.ToListAsync();

            var result = (from d in depts
                          select new  
                          {
                              DeptNo = d.DeptNo,
                              DeptName = d.DeptName,
                          }).ToList();
            return result;
                         
        }

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        async Task<Department> IService<Department, int>.UpdateAsync(int id, Department entity)
        {
            var deptToUpdate = await _context.Departments.FindAsync(id);
            if (deptToUpdate != null) 
            {
                deptToUpdate.DeptName = entity.DeptName;
                deptToUpdate.Capacity = entity.Capacity;
                deptToUpdate.Location = entity.Location;
                await _context.SaveChangesAsync();
                return deptToUpdate;
            }
            return null;
        }
    }
}
