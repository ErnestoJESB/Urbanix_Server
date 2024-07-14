using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Imagenes
{
    public class CreateImageDTO
    {
        public int FkProducto { get; set; }
        public string UrlImg { get; set; }
    }
}
