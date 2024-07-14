using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Inventario
{
    public class InventarioDTO
    {
        public int FkProducto { get; set; }
        public int cantidad { get; set; }
    }
}
