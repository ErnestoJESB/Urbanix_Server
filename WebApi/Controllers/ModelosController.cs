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
        
    }
}
