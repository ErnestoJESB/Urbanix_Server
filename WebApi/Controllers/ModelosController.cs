using Domain.DTOs.Modelos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelosController : Controller
    {
        private readonly IModelosServices _modelosServices;
        public ModelosController(IModelosServices modelosServices)
        {
            _modelosServices = modelosServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetModelos()
        {
            var response = await _modelosServices.GetModelos();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModelo([FromBody] CreateModeloDTO request)
        {
            var response = await _modelosServices.CreateModelo(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var response = await _modelosServices.DeleteModelo(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModelo(int id, [FromBody] CreateModeloDTO request)
        {
            var response = await _modelosServices.UpdateModelo(id, request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeloById(int id)
        {
            var response = await _modelosServices.GetModeloById(id);
            return Ok(response);
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> GetModeloByIdUpdate(int id)
        {
            var response = await _modelosServices.GetModeloByIdUpdate(id);
            return Ok(response);
        }
    }
}
