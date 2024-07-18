using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedidos
    {
        [Key]
        public int PkPedido { get; set; }

        [ForeignKey("Usuarios")]
        public int FkUsuario { get; set; }
        public Usuario usuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Direcciones")]
        public int FkDireccion { get; set; }
        public Direcciones direccion { get; set; }
        public string Estado { get; set; }
    }
}
