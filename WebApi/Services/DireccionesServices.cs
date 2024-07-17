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
    }
}
