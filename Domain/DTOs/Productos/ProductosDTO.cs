using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Productos
{
    public class ProductosDTO
    {
        public int PkProducto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Genero { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
    }
}
