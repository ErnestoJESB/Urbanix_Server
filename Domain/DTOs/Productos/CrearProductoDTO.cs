using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Productos
{
    public class CrearProductoDTO
    {
        public int FkMarca { get; set; }
        public int FkModelo { get; set; }
        public string Genero { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
        public int FkCategoria { get; set; }
        public double Precio { get; set; }
    }
}
