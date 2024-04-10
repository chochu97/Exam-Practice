using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZone
{
    public class AplicacionEntity
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Desarrolladora { get; set; }
        public decimal Precio { get; set; }

    }
}
