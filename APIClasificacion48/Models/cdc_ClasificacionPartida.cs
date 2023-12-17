using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class cdc_ClasificacionPartida
    {
        public int Id { get; set; }
        public int? IdClasificacion { get; set; }
        public int? IdFuentePartida { get; set; }
        public string Fuente { get; set; }
        public string Fraccion { get; set; }
        public string UMT { get; set; }
        public int? IdFraccion { get; set; }
        public string Descripcion { get; set; }
    }
}