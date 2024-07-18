using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Pedidos
{
    public class PedidoDTO
    {
        public int PkPedido { get; set; }
        public int FkUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int FkDireccion { get; set; }
        public string Estado { get; set; }
    }
}
