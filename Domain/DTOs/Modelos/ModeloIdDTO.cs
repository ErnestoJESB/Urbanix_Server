using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Modelos
{
    public class ModeloIdDTO
    {
        public int PkModelo { get; set; }
        public string modelo { get; set; }
        public int FkMarca { get; set; }    
    }
}
