using Domain.DTOs.Direcciones;
using Domain.DTOs.Productos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DireccionesController : Controller
    {
        private readonly IDireccionesServices _direccionesServices;
        public DireccionesController(IDireccionesServices direccionesServices)
        {
            _direccionesServices = direccionesServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetDirecciones()
        {
            var response = await _direccionesServices.GetDirecciones();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDireccion([FromBody] CreateDireccionesDTO request)
        {
            var response = await _direccionesServices.CreateDireccion(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDireccion(int id, [FromBody] CreateDireccionesDTO request)
        {
            var response = await _direccionesServices.UpdateDireccion(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            var response = await _direccionesServices.DeleteDireccion(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDireccionById(int id)
        {
            var response = await _direccionesServices.GetDireccionById(id);
            return Ok(response);
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetDireccionByUser(int id)
        {
            var response = await _direccionesServices.GetDireccionByUser(id);
            return Ok(response);
        }

    }
}
