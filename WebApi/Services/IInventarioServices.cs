using Domain.DTOs.Inventario;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IInventarioServices
    {
        public Task<Response<List<InventarioDTO>>> GetInventario();
        public Task<Response<InventarioDTO>> CreateInventario(InventarioDTO request);
        //public Task<Response<InventarioDTO>> UpdateInventario(int id, InventarioDTO request);
        //public Task<Response<Inventario>> DeleteInventario(int id);
        //public Task<Response<Inventario>> GetInventarioById(int id);
    }
}
