using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class wms_Rev_Factura
    {
        public int id { get; set; }
        public int IDReferencia { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IDProveedor { get; set; }
        public string Incoterm { get; set; }
        public decimal? ImporteTotal { get; set; }
        public double? PesoBruto { get; set; }
        public int? IdUnidadPesoBruto { get; set; }
        public string OrdenCompra { get; set; }
        public string Notas { get; set; }
        public int? idBitacoraRegistro { get; set; }
        public int? IDPais { get; set; }
        public int? IDMoneda { get; set; }
        public decimal? Fletes { get; set; }
        public decimal? Seguros { get; set; }
        public decimal? Embalajes { get; set; }
        public int? Bultos { get; set; }
        public int? IdBultos { get; set; }
        public string Referencia { get; set; }
        public bool? EmbalajeMadera { get; set; }
    }
}