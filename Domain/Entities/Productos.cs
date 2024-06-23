using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Productos
    {
        [Key]
        public int PkProducto { get; set; }

        [ForeignKey("Marca")]
        public int FkMarca { get; set; }
        public Marca marca { get; set; }

        [ForeignKey("Modelo")]
        public int FkModelo { get; set; }
        public Modelo modelo { get; set; }

        public string genero { get; set; }
        public double size { get; set; }
        public string color { get; set; }

        [ForeignKey("Categoria")]
        public int FkCategoria { get; set; }
        public Categoria categoria { get; set; }       

        public double precio { get; set; }
    }
}
