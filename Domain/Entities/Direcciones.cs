using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Direcciones
    {
        [Key]

        public int PkDireccion { get; set; }

        [ForeignKey("Usuario")]
        public int? FkUsuario { get; set; }
        public Usuario usuario { get; set; }
        
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string codigo_postal { get; set; }
        public string pais { get; set; }
    }
}
