using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Productos
{
    public class ProductoTempDTO
    {
        public int PkProducto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Genero { get; set; }
        public string Tallas { get; set; }
        public string Colores { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
    }
}
