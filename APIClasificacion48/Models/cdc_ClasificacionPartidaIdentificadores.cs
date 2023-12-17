using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class cdc_ClasificacionPartidaIdentificadores
    {
        public int Id { get; set; }
        public int IdClasificacionPartida { get; set; }
        public string Clave { get; set; }
        public string Complemento1 { get; set; }
        public string Complemento2 { get; set; }
        public string Complemento3 { get; set; }
    }
}