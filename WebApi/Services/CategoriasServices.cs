using Dapper;
using Domain.DTOs.Categorias;
using Domain.DTOs.Modelos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class CategoriasServices : ICategoriasServices
    {
        private readonly ApplicationDBContext _context;
        public CategoriasServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Categoria>>> GetCategorias()
        {
            try
            {
                List<Categoria> response = new List<Categoria>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Categoria>(
                    "spGetCategorias",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();

                return new Response<List<Categoria>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
        public async Task<Response<CrearCategoriasDTO>> CreateCategoria(CrearCategoriasDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", request.Nombre, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateCategoria", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearCategoriasDTO>(request, "Categoria registrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
        public async Task<Response<Categoria>> GetByID(int id)
        {
            try
            {
                Categoria res = await _context.Categorias.FirstOrDefaultAsync(x => x.PkCategoria == id);
                return new Response<Categoria>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
