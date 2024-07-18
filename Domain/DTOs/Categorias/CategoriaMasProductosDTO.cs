using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Categorias
{
    public class CategoriaMasProductosDTO
    {
        public int PkCategoria { get; set; }
        public string Categoria { get; set; }
        public int CantidadProductos { get; set; }
    }
}
