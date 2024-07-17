using Domain.DTOs.Direcciones;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IDireccionesServices
    {
        public Task<Response<List<DireccionesDTO>>> GetDirecciones();
    }
}
