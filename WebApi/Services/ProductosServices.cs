using Dapper;
using Domain.DTOs.Productos;
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

        public async Task<Response<CrearProductoDTO>> CreateProducto(CrearProductoDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FkMarca", request.FkMarca, DbType.Int32);
                parameters.Add("@FkModelo", request.FkModelo, DbType.Int32);
                parameters.Add("@FkCategoria", request.FkCategoria, DbType.Int32);
                parameters.Add("@Color", request.Color, DbType.String);
                parameters.Add("@Size", request.Size, DbType.String);
                parameters.Add("@Precio", request.Precio, DbType.Double);
                parameters.Add("@Genero", request.Genero, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearProductoDTO>(request, "Usuario registrado exitosamente.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

        public async Task<Response<CrearProductoDTO>> UpdateProducto(int id, CrearProductoDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkProducto", id, DbType.Int32);
                parameters.Add("@FkMarca", request.FkMarca, DbType.Int32);
                parameters.Add("@FkModelo", request.FkModelo, DbType.Int32);
                parameters.Add("@FkCategoria", request.FkCategoria, DbType.Int32);
                parameters.Add("@Color", request.Color, DbType.String);
                parameters.Add("@Size", request.Size, DbType.String);
                parameters.Add("@Precio", request.Precio, DbType.Double);
                parameters.Add("@Genero", request.Genero, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spUpdateProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearProductoDTO>(request, "Producto actualizado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

        public async Task<Response<CrearProductoDTO>> DeleteProducto(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkProducto", id, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spDeleteProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearProductoDTO>(null, "Producto eliminado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

        public async Task<Response<ProductosDTO>> GetProductoById(int id)
        {
            try
            {
                ProductosDTO response = new ProductosDTO();

                var result = await _context.Database.GetDbConnection().QueryAsync<ProductosDTO>(
                    "spGetByIdProduct",
                    new { PkProducto = id },
                    commandType: CommandType.StoredProcedure
                );

                response = result.FirstOrDefault();

                return new Response<ProductosDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
