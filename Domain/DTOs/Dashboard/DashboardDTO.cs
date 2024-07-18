using Domain.DTOs.Categorias;
using Domain.DTOs.Marca;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Dashboard
{
    public class DashboardDTO
    {
        public int TotalProductos { get; set; }
        public int TotalMarcas { get; set; }
        public int TotalCategorias { get; set; }
        public MarcaMasProductoDTO MarcaConMasProductos { get; set; }
        public CategoriaMasProductosDTO CategoriaConMasProductos { get; set; }
    }
}
