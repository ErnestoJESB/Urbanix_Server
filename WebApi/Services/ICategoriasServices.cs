using Domain.DTOs.Categorias;
using Domain.Entities;

namespace WebApi.Services
{
    public interface ICategoriasServices
    {
        public Task<Response<List<Categoria>>> GetCategorias();
        public Task<Response<CrearCategoriasDTO>> CreateCategoria(CrearCategoriasDTO request);
        public Task<Response<Categoria>> GetByID(int id);
    }
}
