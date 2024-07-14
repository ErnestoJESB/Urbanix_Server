using Dapper;
using Domain.DTOs.Inventario;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class InventarioServices : IInventarioServices
    {
        private readonly ApplicationDBContext _context;
        public InventarioServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<InventarioDTO>>> GetInventario()
        {
            try
            {
                List<InventarioDTO> response = new List<InventarioDTO>();
                var result = await _context.Database.GetDbConnection().QueryAsync<InventarioDTO>(
                    "spGetInventario",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();

                return new Response<List<InventarioDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<InventarioDTO>> CreateInventario(InventarioDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FkProducto", request.FkProducto, DbType.Int32);
                parameters.Add("@Cantidad", request.cantidad, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateInventario", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<InventarioDTO>(request, "Inventario registrado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
