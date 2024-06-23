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
    }
}
