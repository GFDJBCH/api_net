using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class cdc_ClasificacionPartidaPermisos
    {
        public int Id { get; set; }
        public int IdClasificacionPartida { get; set; }
        public int? IdPedimento { get; set; }
        public string Clave { get; set; }
        public string FirmaDescargo { get; set; }
        public string NumeroPermiso { get; set; }
        public decimal? ValorComercialDolares { get; set; }
        public decimal? CantidadMercancia { get; set; }
    }
}