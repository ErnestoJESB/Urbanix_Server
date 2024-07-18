using Domain.DTOs.DetallePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Purchase
{
    public class CreatePurchaseDTO
    {
        public int FkUsuario { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string EstadoPedido { get; set; }
        public List<CreateDetallePedidoDTO> DetallesPedido { get; set; }
    }
}
