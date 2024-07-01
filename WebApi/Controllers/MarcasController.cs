using Domain.DTOs.Marca;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcasController : Controller
    {
        private readonly IMarcasServices _marcasServices;
        public MarcasController(IMarcasServices marcasServices)
        {
            _marcasServices = marcasServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarcas()
        {
            var response = await _marcasServices.GetMarcas();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarca([FromBody] CreateMarcaDTO request)
        {
            var response = await _marcasServices.CreateMarca(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarca(int id, [FromBody] CreateMarcaDTO request)
        {
            var response = await _marcasServices.UpdateMarca(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var response = await _marcasServices.DeleteMarca(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _marcasServices.GetByID(id);
            return Ok(response);
        }
    }
}
