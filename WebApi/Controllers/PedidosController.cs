using Domain.DTOs.DetallePedido;
using Domain.DTOs.Pedidos;
using Domain.DTOs.Purchase;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoServices _pedidoServices;
        public PedidosController(IPedidoServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            var response = await _pedidoServices.GetPedidos();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] CreatePedidoDTO createPedidoDTO)
        {
            if (createPedidoDTO == null)
            {
                return BadRequest("Pedido no puede ser nulo");
            }

            var result = await _pedidoServices.CreatePedido(createPedidoDTO);

            if (result == null)
            {
                return StatusCode(500, "Un error ocurrió mientras se creaba el pedido");
            }

            return Ok(result);
        }

        [HttpPost("{pedidoId}/detalles")]
        public async Task<IActionResult> AddPedidoDetalle(int pedidoId, [FromBody] CreatePedidoDetalleDTO createPedidoDetalleDTO)
        {
            if (createPedidoDetalleDTO == null)
            {
                return BadRequest("Detalle del pedido no puede ser nulo");
            }

            createPedidoDetalleDTO.FkPedido = pedidoId;
            var result = await _pedidoServices.AddPedidoDetalle(createPedidoDetalleDTO);

            if (result == null)
            {
                return StatusCode(500, "Un error ocurrió mientras se agregaba el detalle del pedido");
            }

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPedidoByUserId(int id)
        {
            var response = await _pedidoServices.GetPedidoByUserId(id);
            return Ok(response);
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseDTO createPurchaseDTO)
        {
            if (createPurchaseDTO == null)
            {
                return BadRequest("La solicitud no puede ser nula");
            }

            var result = await _pedidoServices.CreatePurchase(createPurchaseDTO);

            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }

            return Ok(new { mensaje = "Compra creada exitosamente", PkPedido = result.Result });
        }
    }
}
