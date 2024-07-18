using Domain.DTOs.DetallePedido;
using Domain.DTOs.Pedidos;
using Domain.DTOs.Purchase;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IPedidoServices
    {
        public Task<Response<List<PedidoDTO>>> GetPedidos();
        public Task<Response<CreatePedidoDTO>> CreatePedido(CreatePedidoDTO request);
        public Task<Response<CreatePedidoDetalleDTO>> AddPedidoDetalle(CreatePedidoDetalleDTO request);            
        public Task<Response<PedidoDTO>> GetPedidoByUserId(int id);

        public Task<Response<int>> CreatePurchase(CreatePurchaseDTO request);
    }
}
