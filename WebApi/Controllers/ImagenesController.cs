using Domain.DTOs.Imagenes;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagenesController : Controller
    {
        private readonly IImagenServices _imagenesServices;
        public ImagenesController(IImagenServices imagenesServices)
        {
            _imagenesServices = imagenesServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetImagenes()
        {
            var response = await _imagenesServices.GetImagenes();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody] CreateImageDTO request)
        {
            var response = await _imagenesServices.CreateImage(request);
            return Ok(response);
        }

    }
}
