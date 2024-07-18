using Dapper;
using Domain.DTOs.DetallePedido;
using Domain.DTOs.Pedidos;
using Domain.DTOs.Productos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class PedidoServices: IPedidoServices
    {
        private readonly ApplicationDBContext _context;
        public PedidoServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<PedidoDTO>>> GetPedidos()
        {
            try
            {
               List<PedidoDTO> response = new List<PedidoDTO>();
                var result = await _context.Database.GetDbConnection().QueryAsync<PedidoDTO>(
                    "spGetPedido",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();

                return new Response<List<PedidoDTO>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error catastrófico: " + ex.Message);
            }
        }

        public async Task<Response<CreatePedidoDTO>> CreatePedido(CreatePedidoDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("FkUsuario", request.FkUsuario);
                parameters.Add("Fecha", request.Fecha);
                parameters.Add("Total", request.Total);
                parameters.Add("FkDireccion", request.FkDireccion);
                parameters.Add("Estado", request.Estado);
                parameters.Add("PkPedido", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync(
                        "spCreatePedido",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    var pkPedido = parameters.Get<int>("PkPedido");
                    request.PkPedido = pkPedido;

                    return new Response<CreatePedidoDTO>(request);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error catastrófico: " + ex.Message);
            }
        }

        public async Task<Response<CreatePedidoDetalleDTO>> AddPedidoDetalle(CreatePedidoDetalleDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("FkPedido", request.FkPedido);
                parameters.Add("FkProducto", request.FkProducto);
                parameters.Add("Cantidad", request.Cantidad);
                parameters.Add("Precio", request.Precio);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync(
                        "spAddPedidoDetalle",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return new Response<CreatePedidoDetalleDTO>(request);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error catastrófico: " + ex.Message);
            }
        }

        public async Task<Response<PedidoDTO>> GetPedidoByUserId(int id)
        {
            try
            {
                PedidoDTO response = new PedidoDTO();
                var result = await _context.Database.GetDbConnection().QueryAsync<PedidoDTO>(
                    "spGetPedidoByUserId",
                    new { FkUsuario = id },
                    commandType: CommandType.StoredProcedure
                );

                response = result.FirstOrDefault();

                return new Response<PedidoDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error catastrófico: " + ex.Message);
            }
        }
    }
}
