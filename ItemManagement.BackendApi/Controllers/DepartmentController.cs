using ItemManagement.Api.Repositories;
using ItemManagement.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<Department>> CreateNewDepartment([FromBody] Department department)
        {
            var newDepartment = await _departmentRepository.CreateNewDepartment(department);
            return CreatedAtAction(nameof(GetADepartment), new { DepartmentId = newDepartment.Id }, newDepartment);
        }

        /// <summary>
        /// This method to Update information of a Department
        /// </summary>
        [HttpPut("{departmentId}")]
        public async Task<ActionResult> UpdateDepartment(int departmentId, [FromForm] Department department)
        {
            if (departmentId != department.Id)
            {
                return BadRequest();
            }
            await _departmentRepository.UpdateDepartment(department);
            return Ok();
        }

        /// <summary>
        /// This method to Delete Department
        /// </summary>
        /// <response code="200">Department deleted successfully</response>
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult> DeleteDepartment(int departmentId)
        {
            var departmentToDelete = await _departmentRepository.GetADepartment(departmentId);
            if (departmentToDelete == null)
                return NotFound();

            await _departmentRepository.DeleteDepartment(departmentToDelete.Id);
            return Ok();
        }
    }
}