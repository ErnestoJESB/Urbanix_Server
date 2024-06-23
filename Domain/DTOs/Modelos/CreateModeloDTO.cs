using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Modelos
{
    public class CreateModeloDTO
    {
        public string Nombre { get; set; }
        public int FkMarca { get; set; }
    }
}
