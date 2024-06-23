using Dapper;
using Domain.DTOs.Modelos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class ModelosServices : IModelosServices
    {
        private readonly ApplicationDBContext _context;
        public ModelosServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<ModelosDTO>>> GetModelos()
        {
            try
            {
                List<ModelosDTO> response = new List<ModelosDTO>();
                var result = await _context.Database.GetDbConnection().QueryAsync<ModelosDTO>(
                    "spGetModelos",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();

                return new Response<List<ModelosDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
