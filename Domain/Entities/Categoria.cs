using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }
        public string categoria { get; set; }
        public string UrlImg { get; set; }
    }
}
