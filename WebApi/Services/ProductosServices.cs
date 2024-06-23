using Dapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class ProductosServices : IProductosServices
    {
        private readonly ApplicationDBContext _context;

        public ProductosServices(ApplicationDBContext context)
        {
            _context = context;
        }
        //Obtencion de todos los productos
        public async Task<Response<List<ProductosDTO>>> GetProductos()
        {
            try
            {
                List<ProductosDTO> response = new List<ProductosDTO>();

                var result = await _context.Database.GetDbConnection().QueryAsync<ProductosDTO>(
                    "spGetProductos",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();

                return new Response<List<ProductosDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

    }
}
