using CRUD.API.Models.MongoModels;
using CRUD.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeStaffsController : ControllerBase
    {
        private readonly IOfficeStaffService _officeStaffService;

        public OfficeStaffsController(IOfficeStaffService officeStaffService)
        {
            _officeStaffService = officeStaffService ?? throw new ArgumentNullException(nameof(officeStaffService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeStaff>>> GetAllOfficeStaff()
        {
            var officeStaff = await _officeStaffService.GetAllOfficeStaffAsync();
            return Ok(officeStaff);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeStaff>> GetOfficeStaffById(string id)
        {
            var officeStaff = await _officeStaffService.GetOfficeStaffByIdAsync(id);
            if (officeStaff == null)
            {
                return NotFound();
            }
            return Ok(officeStaff);
        }

        [HttpPost]
        public async Task<ActionResult> AddOfficeStaff([FromBody] OfficeStaff officeStaff)
        {
            await _officeStaffService.AddOfficeStaffAsync(officeStaff);
            return CreatedAtAction(nameof(GetOfficeStaffById), new { id = officeStaff.Id }, officeStaff);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOfficeStaff(string id, [FromBody] OfficeStaff officeStaff)
        {
            try
            {
                await _officeStaffService.UpdateOfficeStaffAsync(id, officeStaff);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOfficeStaff(string id)
        {
            try
            {
                await _officeStaffService.DeleteOfficeStaffAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
