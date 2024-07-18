using Dapper;
using Domain.DTOs.Categorias;
using Domain.DTOs.Dashboard;
using Domain.DTOs.Inventario;
using Domain.DTOs.Marca;
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

        public async Task<Response<CrearInventarioDTO>> CreateInventario(CrearInventarioDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FkProducto", request.FkProducto, DbType.Int32);
                parameters.Add("@Cantidad", request.cantidad, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateInventario", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearInventarioDTO>(request, "Inventario registrado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<CrearInventarioDTO>> UpdateInventario(int id, CrearInventarioDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkInventario", id, DbType.Int32);
                parameters.Add("@FkProducto", request.FkProducto, DbType.Int32);
                parameters.Add("@cantidad", request.cantidad, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spUpdateInventario", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearInventarioDTO>(request, "Inventario actualizado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
        public async Task<Response<Inventario>> DeleteInventario(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkInventario", id, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spDeleteInventario", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<Inventario>("Inventario eliminado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
        
        public async Task<Response<InventarioDTO>> GetInventarioById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkInventario", id, DbType.Int32);
                InventarioDTO response = new InventarioDTO();
                var result = await _context.Database.GetDbConnection().QueryAsync<InventarioDTO>(
                    "spGetInventarioById",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                response = result.FirstOrDefault();

                return new Response<InventarioDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<DashboardDTO>> GetResumenDashboard()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var result = new DashboardDTO();

                    using (var multi = await connection.QueryMultipleAsync("spGetResumenDashboard", commandType: CommandType.StoredProcedure))
                    {
                        result.TotalProductos = multi.Read<int>().Single();
                        result.TotalMarcas = multi.Read<int>().Single();
                        result.TotalCategorias = multi.Read<int>().Single();
                        result.MarcaConMasProductos = multi.Read<MarcaMasProductoDTO>().SingleOrDefault();
                        result.CategoriaConMasProductos = multi.Read<CategoriaMasProductosDTO>().SingleOrDefault();
                    }

                    return new Response<DashboardDTO>(result, "Resumen obtenido exitosamente");
                }
            }
            catch (Exception ex)
            {
                return new Response<DashboardDTO>("Sucedió un error catastrófico: " + ex.Message);
            }
        }
    }
}
