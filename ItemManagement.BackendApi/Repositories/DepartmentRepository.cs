using ItemManagement.Data.Models.Entities;
using ItemManagerment.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Department> CreateNewDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var departmentToDelete = await _context.Departments.FindAsync(departmentId);
            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetADepartment(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task UpdateDepartment(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}