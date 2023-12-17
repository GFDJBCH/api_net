using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class _Catalogos
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Grupo { get; set; }
        public string Codigo { get; set; }
        public string ValorTexto { get; set; }
        public decimal? ValorNumerico { get; set; }
        public bool? ValorBoleano { get; set; }
        public string Descripcion { get; set; }
        public string ValorTextoIngles { get; set; }
        public string DescripcionIngles { get; set; }
        public int? Orden { get; set; }
        public int IdBitacoraRegistro { get; set; }
        public int? IdRelacion { get; set; }
        public bool EsSistema { get; set; }
    }
}