using Dapper;
using Domain.DTOs.Marca;
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
        public async Task<Response<CreateMarcaDTO>> CreateMarca(CreateMarcaDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", request.marca, DbType.String);
                parameters.Add("@Url", request.UrlImg, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateMarca", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CreateMarcaDTO>(request, "Marca registrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<CreateMarcaDTO>> UpdateMarca(int id, CreateMarcaDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkMarca", id, DbType.Int32);
                parameters.Add("@Marca", request.marca, DbType.String);
                parameters.Add("@Url", request.UrlImg, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spUpdateMarca", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CreateMarcaDTO>(request, "Marca actualizada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<Marca>> DeleteMarca(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkMarca", id, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spDeleteMarca", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<Marca>(new Marca(), "Marca eliminada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<Marca>> GetByID(int id)
        {
            try
            {
                Marca res = await _context.Marcas.FirstOrDefaultAsync(x => x.PkMarca == id);

                return new Response<Marca>(res);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
