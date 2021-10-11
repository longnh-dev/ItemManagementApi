using ItemManagement.Api.Repositories;
using ItemManagement.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)

        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentRepository.Get();
        }

        [HttpGet("{DepartmentId}")]
        public async Task<ActionResult<Department>> GetDepartment(int DepartmentId)
        {
            return await _departmentRepository.Get(DepartmentId);
        }
    }
}