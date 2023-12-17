using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class cdc_Clasificacion
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public int? IdFuente { get; set; }
        public string Fuente { get; set; }
        public int? IdBitacoraRegistro { get; set; }
        public int? IdEstatus { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? IdClavePedimento { get; set; }
        public int? IdZona { get; set; }
    }
}