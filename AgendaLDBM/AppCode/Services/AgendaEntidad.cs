using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaLDBM.Services
{
    public class AgendaEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Télefono { get; set; }
        public string Notas { get; set; }
    }
}