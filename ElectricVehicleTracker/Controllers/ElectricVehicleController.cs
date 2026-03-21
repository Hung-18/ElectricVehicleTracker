using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectricVehicleTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricVehicleController : ControllerBase
    {
        private readonly IElectricVehicleService _evService;
        public ElectricVehicleController(IElectricVehicleService evService)
        {
            _evService = evService;
        }
        [HttpGet]
        public async Task<ActionResult<PageResult<VehicleDTO>>> GetAllVehicle([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var vehicle = await _evService.PageResultAsync(page, pageSize);
            return Ok(vehicle);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(Guid id)
        {
            var vehicle = await _evService.GetVehicleByIdAsync(id);
            return Ok(vehicle);
        }
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody]CreateVehicleDTO createVehicleDto)
        {
            try
            {
                await _evService.AddVehicleAsync(createVehicleDto);
                return Ok("thanhcong");
                //return CreatedAtAction(nameof(GetAllVehicle), null);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message+ " | "+ ex.InnerException?.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateVehicle(UpdateVehicleDTO updateVehicleDto, Guid id)
        {
            try
            {
                await _evService.UpdateVehicleAsync(id, updateVehicleDto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid userId,Guid id)
        {
            try
            {
                await _evService.DeleteVehicleAsync(userId,id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
