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
        public async Task<IActionResult> CreateInventario([FromBody] InventarioDTO request)
        {
            var response = await _inventarioServices.CreateInventario(request);
            return Ok(response);
        }   
    }
}
