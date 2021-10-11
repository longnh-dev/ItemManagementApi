using ItemManagement.Data.Models.Entities;
using ItemManagerment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.Api.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ItemManagementDbContext _context;

        public DepartmentRepository(ItemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task Delete(int DepartmentId)
        {
            var departmentToDelete = await _context.Departments.FindAsync(DepartmentId);
            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> Get(int DepartmentId)
        {
            return await _context.Departments.FindAsync(DepartmentId);
        }

        public async Task Update(Department department)
        {
            _context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}