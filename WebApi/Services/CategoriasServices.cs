using Dapper;
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
    }
}
