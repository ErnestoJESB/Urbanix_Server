using Domain.DTOs.Productos;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IProductosServices
    {
        public Task<Response<List<ProductosDTO>>> GetProductos();
        public Task<Response<CrearProductoDTO>> CreateProducto(CrearProductoDTO request);
        public Task<Response<CrearProductoDTO>> UpdateProducto(int id, CrearProductoDTO request);
        public Task<Response<CrearProductoDTO>> DeleteProducto(int id);
        public Task<Response<ProductosDTO>> GetProductoById(int id);
        public Task<Response<ProductoIdDTO>> GetProductoByIdUpdate(int id);
    }
}
