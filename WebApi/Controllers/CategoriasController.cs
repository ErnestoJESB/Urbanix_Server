using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : Controller 
    {
        private readonly ICategoriasServices _categoriasServices;
        public CategoriasController(ICategoriasServices categoriasServices)
        {
            _categoriasServices = categoriasServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var response = await _categoriasServices.GetCategorias();
            return Ok(response);
        }
    }
}
