using Domain.DTOs.Productos;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IProductosServices
    {
        public Task<Response<List<ProductosDTO>>> GetProductos();
        public Task<Response<CrearProductoDTO>> CreateProducto(CrearProductoDTO request);
    }
}
