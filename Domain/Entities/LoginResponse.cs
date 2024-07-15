using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LoginResponse
    {
        public bool Resultado { get; set; }
        public string Rol { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
