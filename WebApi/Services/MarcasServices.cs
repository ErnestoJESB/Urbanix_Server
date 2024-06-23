using Dapper;
using Domain.DTOs.Productos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class MarcasServices : IMarcasServices
    {
        private readonly ApplicationDBContext _context;
        public MarcasServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Marca>>> GetMarcas()
        {
            try
            {
                List<Marca> response = new List<Marca>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Marca>(
                    "spGetMarcas",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();

                return new Response<List<Marca>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
