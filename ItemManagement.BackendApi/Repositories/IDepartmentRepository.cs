using ItemManagement.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.Api.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartment();

        Task<Department> GetADepartment(int departmentId);

        Task<Department> CreateNewDepartment(Department department);

        Task UpdateDepartment(Department department);

        Task DeleteDepartment(int departmentId);
    }
}