using Dapper;
using Domain.DTOs.Direcciones;
using Domain.DTOs.Productos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;
using WebApi.Helpers;

namespace WebApi.Services
{
    public class DireccionesServices : IDireccionesServices
    {
        private readonly ApplicationDBContext _context;
        public DireccionesServices(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<Response<List<DireccionesDTO>>> GetDirecciones()
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<DireccionesDTO>(
                    "spGetDirecciones",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                var response = result.Select(item => new DireccionesDTO
                {
                    PkDireccion = item.PkDireccion,
                    FkUsuario = item.FkUsuario,
                    direccion = item.direccion,
                    ciudad = item.ciudad,
                    estado = item.estado,
                    codigo_postal = item.codigo_postal,
                    pais = item.pais

                }).ToList();

                return new Response<List<DireccionesDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<CreateDireccionesDTO>> CreateDireccion(CreateDireccionesDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("FkUsuario", request.FkUsuario);
                parameters.Add("Direccion", request.direccion);
                parameters.Add("Ciudad", request.ciudad);
                parameters.Add("Estado", request.estado);
                parameters.Add("Codigo_postal", request.codigo_postal);
                parameters.Add("Pais", request.pais);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync(
                        "spCreateDirecciones",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return new Response<CreateDireccionesDTO>(request);
                }            
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<CreateDireccionesDTO>> UpdateDireccion(int id, CreateDireccionesDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PkDireccion", id);
                parameters.Add("FkUsuario", request.FkUsuario);
                parameters.Add("Direccion", request.direccion);
                parameters.Add("Ciudad", request.ciudad);
                parameters.Add("Estado", request.estado);
                parameters.Add("Codigo_postal", request.codigo_postal);
                parameters.Add("Pais", request.pais);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync(
                        "spUpdateDirecciones",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return new Response<CreateDireccionesDTO>(request);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<CreateDireccionesDTO>> DeleteDireccion(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PkDireccion", id);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync(
                        "spDeleteDireccion",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return new Response<CreateDireccionesDTO>(new CreateDireccionesDTO());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<DireccionesDTO>> GetDireccionById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PkDireccion", id);

                var result = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<DireccionesDTO>(
                    "spGetByIdDireccion",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var response = new DireccionesDTO
                {
                    PkDireccion = result.PkDireccion,
                    FkUsuario = result.FkUsuario,
                    direccion = result.direccion,
                    ciudad = result.ciudad,
                    estado = result.estado,
                    codigo_postal = result.codigo_postal,
                    pais = result.pais
                };

                return new Response<DireccionesDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
        public async Task<Response<List<DireccionesDTO>>> GetDireccionByUser(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("FkUsuario", id);

                var result = await _context.Database.GetDbConnection().QueryAsync<DireccionesDTO>(
                    "spGetDireccionByIdUser",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var response = result.Select(item => new DireccionesDTO
                {
                    PkDireccion = item.PkDireccion,
                    FkUsuario = item.FkUsuario,
                    direccion = item.direccion,
                    ciudad = item.ciudad,
                    estado = item.estado,
                    codigo_postal = item.codigo_postal,
                    pais = item.pais

                }).ToList();

                return new Response<List<DireccionesDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
