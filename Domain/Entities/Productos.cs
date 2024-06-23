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

    public class Marca
    {
        [Key]
        public int PkMarca { get; set; }
        public string marca { get; set; }
    }

    public class Modelo
    {
        [Key]
        public int PkModelo { get; set; }
        public string modelo { get; set; }
        [ForeignKey("Marca")]
        public int FkMarca { get; set; }
        public Marca marca { get; set; }
    }

    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }
        public string categoria { get; set; }
    }
}
