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
    }
}
