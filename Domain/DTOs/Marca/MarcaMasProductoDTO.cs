using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Marca
{
    public class MarcaMasProductoDTO
    {
        public int PkMarca { get; set; }
        public string Marca { get; set; }
        public int CantidadProductos { get; set; }
    }
}
