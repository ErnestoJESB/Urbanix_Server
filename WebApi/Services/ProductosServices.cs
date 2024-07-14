using Dapper;
using Domain.DTOs.Productos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using WebApi.Context;
using WebApi.Helpers;

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
                var result = await _context.Database.GetDbConnection().QueryAsync<ProductoTempDTO>(
                    "spGetProductos",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                var response = result.Select(item => new ProductosDTO
                {
                    PkProducto = item.PkProducto,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Genero = item.Genero,
                    Tallas = item.Tallas.ToDoubleList(),
                    Colores = item.Colores.ToStringList(),
                    Categoria = item.Categoria,
                    Precio = item.Precio
                }).ToList();

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
                parameters.Add("@Colores", JsonConvert.SerializeObject(request.Colores), DbType.String);
                parameters.Add("@Tallas", JsonConvert.SerializeObject(request.Tallas), DbType.String);
                parameters.Add("@Precio", request.Precio, DbType.Double);
                parameters.Add("@Genero", request.Genero, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CrearProductoDTO>(request, "Producto registrado exitosamente.");
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
                parameters.Add("@Colores", JsonConvert.SerializeObject(request.Colores), DbType.String);
                parameters.Add("@Tallas", JsonConvert.SerializeObject(request.Tallas), DbType.String);
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
               var parameters = new DynamicParameters();
                parameters.Add("@PkProducto", id, DbType.Int32);

                var result = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<ProductoTempDTO>(
                    "spGetByIdProduct",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (result == null)
                {
                    return new Response<ProductosDTO>("No se encontró el producto.");
                }

                var response = new ProductosDTO
                {
                    PkProducto = result.PkProducto,
                    Marca = result.Marca,
                    Modelo = result.Modelo,
                    Genero = result.Genero,
                    Tallas = result.Tallas.ToDoubleList(),
                    Colores = result.Colores.ToStringList(),
                    Categoria = result.Categoria,
                    Precio = result.Precio
                };

                return new Response<ProductosDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
        
        public async Task<Response<ProductoIdDTO>> GetProductoByIdUpdate(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PkProducto", id, DbType.Int32);

                var result = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<ProductoTempUpdateDTO>(
                    "spGetProductByIdUpdate",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (result == null)
                {
                    return new Response<ProductoIdDTO>("No se encontró el producto.");
                }

                var response = new ProductoIdDTO
                {
                    PkProducto = result.PkProducto,
                    FkMarca = result.FkMarca,
                    FkModelo = result.FkModelo,
                    FkCategoria = result.FkCategoria,
                    Colores = result.Colores.ToStringList(),
                    Tallas = result.Tallas.ToDoubleList(),
                    Precio = result.Precio,
                    Genero = result.Genero,
                };

                return new Response<ProductoIdDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<List<ProductosDTO>>> GetProductosByCategory(int? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FkCategoria", id, DbType.Int32);

                var result = await _context.Database.GetDbConnection().QueryAsync<ProductoTempDTO>(
                    "spGetProductsByCategory",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var response = result.Select(item => new ProductosDTO
                {
                    PkProducto = item.PkProducto,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Genero = item.Genero,
                    Tallas = item.Tallas.ToDoubleList(),
                    Colores = item.Colores.ToStringList(),
                    Categoria = item.Categoria,
                    Precio = item.Precio
                }).ToList();

                return new Response<List<ProductosDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error catastrófico: " + ex.Message);
            }
        }

        public async Task<Response<List<ProductosDTO>>> GetLatestProducts()
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<ProductoTempDTO>(
                    "spGetLatestProducts",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                var response = result.Select(item => new ProductosDTO
                {
                    PkProducto = item.PkProducto,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Genero = item.Genero,
                    Tallas = item.Tallas.ToDoubleList(),
                    Colores = item.Colores.ToStringList(),
                    Categoria = item.Categoria,
                    Precio = item.Precio
                }).ToList();

                return new Response<List<ProductosDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<List<ProductosDTO>>> GetUniqueProducts()
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<ProductoTempDTO>(
                    "spGetUniqueProducts",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                var response = result.Select(item => new ProductosDTO
                {
                    PkProducto = item.PkProducto,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Genero = item.Genero,
                    Tallas = item.Tallas.ToDoubleList(),
                    Colores = item.Colores.ToStringList(),
                    Categoria = item.Categoria,
                    Precio = item.Precio
                }).ToList();

                return new Response<List<ProductosDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }
    }
}
