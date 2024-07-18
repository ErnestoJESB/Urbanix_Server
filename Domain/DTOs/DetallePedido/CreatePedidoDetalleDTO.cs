using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.DetallePedido
{
    public class CreatePedidoDetalleDTO
    {
        public int FkPedido { get; set; }
        public int FkProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

}
