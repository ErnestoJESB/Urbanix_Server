using Domain.DTOs.Inventario;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController : Controller
    {
        private readonly IInventarioServices _inventarioServices;
        public InventarioController(IInventarioServices inventarioServices)
        {
            _inventarioServices = inventarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventario()
        {
            var response = await _inventarioServices.GetInventario();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventario([FromBody] CrearInventarioDTO request)
        {
            var response = await _inventarioServices.CreateInventario(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventario(int id, [FromBody] CrearInventarioDTO request)
        {
            var response = await _inventarioServices.UpdateInventario(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var response = await _inventarioServices.DeleteInventario(id);
            return Ok(response);
        }

        [HttpGet("ByProduct/{id}")]
        public async Task<IActionResult> GetInventarioById(int id)
        {
            var response = await _inventarioServices.GetInventarioById(id);
            return Ok(response);
        }
    }
}
