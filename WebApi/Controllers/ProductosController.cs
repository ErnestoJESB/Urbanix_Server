using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        private readonly IProductosServices _productosServices;
        public ProductosController(IProductosServices productosServices)
        {
            _productosServices = productosServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var response = await _productosServices.GetProductos();
            return Ok(response);
        }

    }
}
