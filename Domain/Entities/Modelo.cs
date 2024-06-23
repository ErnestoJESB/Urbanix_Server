using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Modelo
    {
        [Key]
        public int PkModelo { get; set; }
        public string modelo { get; set; }
        [ForeignKey("Marca")]
        public int? FkMarca { get; set; }
        public Marca marca { get; set; }
    }
}
