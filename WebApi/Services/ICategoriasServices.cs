using Domain.Entities;

namespace WebApi.Services
{
    public interface ICategoriasServices
    {
        public Task<Response<List<Categoria>>> GetCategorias();
    }
}
