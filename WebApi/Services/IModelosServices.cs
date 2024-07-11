using Domain.DTOs.Modelos;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IModelosServices
    {
        public Task<Response<List<ModelosDTO>>> GetModelos();
        public Task<Response<CreateModeloDTO>> CreateModelo(CreateModeloDTO request);
        public Task<Response<ModelosDTO>> GetModeloById(int id);
        public Task<Response<CreateModeloDTO>> UpdateModelo(int id, CreateModeloDTO request);
        public Task<Response<Modelo>> DeleteModelo(int id);
        public Task<Response<ModeloIdDTO>> GetModeloByIdUpdate(int id);
    }
}
