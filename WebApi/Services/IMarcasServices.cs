using Domain.Entities;

namespace WebApi.Services
{
    public interface IMarcasServices
    {
        public Task<Response<List<Marca>>> GetMarcas();
    }
}
