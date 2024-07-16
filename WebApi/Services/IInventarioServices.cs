using Domain.DTOs.Inventario;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IInventarioServices
    {
        public Task<Response<List<InventarioDTO>>> GetInventario();
        public Task<Response<CrearInventarioDTO>> CreateInventario(CrearInventarioDTO request);
        public Task<Response<CrearInventarioDTO>> UpdateInventario(int id, CrearInventarioDTO request);
        public Task<Response<Inventario>> DeleteInventario(int id);
        public Task<Response<InventarioDTO>> GetInventarioById(int id);
    }
}
