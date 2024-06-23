using Domain.DTOs.Modelos;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IModelosServices
    {
        public Task<Response<List<ModelosDTO>>> GetModelos();
    }
}
