using Domain.DTOs.Direcciones;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IDireccionesServices
    {
        public Task<Response<List<DireccionesDTO>>> GetDirecciones();
        public Task<Response<CreateDireccionesDTO>> CreateDireccion(CreateDireccionesDTO request);
        public Task<Response<CreateDireccionesDTO>> UpdateDireccion(int id, CreateDireccionesDTO request);
        public Task<Response<CreateDireccionesDTO>> DeleteDireccion(int id);
        public Task<Response<DireccionesDTO>> GetDireccionById(int id);
        public Task<Response<List<DireccionesDTO>>> GetDireccionByUser(int id);
    }
}
