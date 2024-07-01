using Domain.DTOs.Marca;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IMarcasServices
    {
        public Task<Response<List<Marca>>> GetMarcas();
        public Task<Response<CreateMarcaDTO>> CreateMarca(CreateMarcaDTO request);
        public Task<Response<Marca>> GetByID(int id);
        public Task<Response<CreateMarcaDTO>> UpdateMarca(int id, CreateMarcaDTO request);
        public Task<Response<Marca>> DeleteMarca(int id);
    }
}
