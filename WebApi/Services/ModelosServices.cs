using Dapper;
using Domain.DTOs.Modelos;
using Domain.DTOs.Productos;
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
        public async Task<Response<CreateModeloDTO>> CreateModelo(CreateModeloDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", request.modelo, DbType.String);
                parameters.Add("@FkMarca", request.FkMarca, DbType.Int32);
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateModelos", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CreateModeloDTO>(request, "Modelo registrado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<CreateModeloDTO>> UpdateModelo(int id, CreateModeloDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkModelo", id, DbType.Int32);
                parameters.Add("@Modelo", request.modelo, DbType.String);
                parameters.Add("@FkMarca", request.FkMarca, DbType.Int32);
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spUpdateModelo", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CreateModeloDTO>(request, "Modelo actualizado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<Modelo>> DeleteModelo(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkModelo", id, DbType.Int32);
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spDeleteModelo", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<Modelo>(new Modelo(), "Modelo eliminado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<ModelosDTO>> GetModeloById(int id)
        {
            try
            {
                ModelosDTO response = new ModelosDTO();
                var result = await _context.Database.GetDbConnection().QueryAsync<ModelosDTO>(
                    "spGetByIdModelo",
                    new { PkModelo = id },
                    commandType: CommandType.StoredProcedure
                );

                response = result.FirstOrDefault();

                return new Response<ModelosDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<ModeloIdDTO>> GetModeloByIdUpdate(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkModelo", id, DbType.Int32);

                var result = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<ModeloIdDTO>(
                    "spGetByIdModelUpdate",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (result == null)
                {
                    return new Response<ModeloIdDTO>("No se encontró el modelo.");
                }

                return new Response<ModeloIdDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
