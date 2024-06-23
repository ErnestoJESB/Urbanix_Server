using Domain.DTOs;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IProductosServices
    {
        public Task<Response<List<ProductosDTO>>> GetProductos();
    }
}
