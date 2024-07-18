using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PedidoDetalle
    {
        [Key]
        public int PkDetalle { get; set; }

        [ForeignKey("Pedidos")]
        public int FkPedido { get; set; }
        public Pedidos Pedido { get; set; }

        [ForeignKey("Productos")]
        public int FkProducto { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
