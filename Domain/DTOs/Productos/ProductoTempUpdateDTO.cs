using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Productos
{
    public class ProductoTempUpdateDTO
    {
        public int PkProducto { get; set; }
        public int FkMarca { get; set; }
        public int FkModelo { get; set; }
        public int FkCategoria { get; set; }
        public string Colores { get; set; }
        public string Tallas { get; set; }
        public double Precio { get; set; }
        public string Genero { get; set; }
    }
}
