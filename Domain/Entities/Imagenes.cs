using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Imagenes
    {
        [Key]
        public int PkImagen { get; set; }
        [ForeignKey("Productos")]
        public int FkProducto { get; set; }
        public Productos producto { get; set; }
        public string UrlImg { get; set; }
    }
}
