﻿using System;
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
        public List<double> Tallas { get; set; }
        public List<string> Colores { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
    }
}
