using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Direcciones
{
    public class CreateDireccionesDTO
    {
        public int? PkDireccion { get; set; }
        public int FkUsuario { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string codigo_postal { get; set; }
        public string pais { get; set; }
    }
}
