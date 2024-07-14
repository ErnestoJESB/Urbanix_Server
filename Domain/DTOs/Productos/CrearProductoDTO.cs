using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Productos
{
    public class CrearProductoDTO
    {
        public int? PkProducto { get; set; }
        public int FkMarca { get; set; }
        public int FkModelo { get; set; }
        public string Genero { get; set; }
        public List<double> Tallas { get; set; }
        public List<string> Colores { get; set; }
        public int FkCategoria { get; set; }
        public double Precio { get; set; }
    }
}
