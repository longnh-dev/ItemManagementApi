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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        //Get all department
        /// <summary>
        /// This method to get all Department info
        /// </summary>
        /// <returns>A list of Department</returns>
        /// <remarks>
        /// Sample request
        /// GET api/departments
        /// </remarks>
        [HttpGet]
        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await _departmentRepository.GetAllDepartment();
        }

        //Get Department
        /// <summary>
        /// This method to get a Department
        /// </summary>
        /// <returns> Return department by Id</returns>
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<Department>> GetADepartment(int departmentId)
        {
            return await _departmentRepository.GetADepartment(departmentId);
        }

        /// <summary>
        /// This method to Create a Department
        /// </summary>
        /// <param name="department">Request's payload</param>
        /// <returns></returns>
        /// <response code="201">Department created successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department department)
        {
            var newDepartment = await _departmentRepository.Create(department);
            return CreatedAtAction(nameof(GetADepartment), new { DepartmentId = newDepartment.DepartmentId }, newDepartment);
        }

        /// <summary>
        /// This method to Update information of a Department
        /// </summary>
        [HttpPut("{departmentId}")]
        public async Task<ActionResult> UpdateDepartment(int departmentId, [FromForm] Department department)
        {
            if (departmentId != department.DepartmentId)
            {
                return BadRequest();
            }
            await _departmentRepository.Update(department);
            return Ok(department);
        }

        /// <summary>
        /// This method to Delete Department
        /// </summary>
        /// <response code="201">Department deleted successfully</response>
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult> DeleteDepartment(int departmentId)
        {
            var departmentToDelete = await _departmentRepository.GetADepartment(departmentId);
            if (departmentToDelete == null)
                return NotFound();

            await _departmentRepository.Delete(departmentToDelete.DepartmentId);
            return Ok();
        }
    }
}