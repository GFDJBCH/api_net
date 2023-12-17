using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class vw_cdc_clasificacion
    {
        public int id { get; set; }
        public string referencia { get; set; }
        public int? idSucursal { get; set; }
        public string codigoSucursal { get; set; }
        public string descripcionSucursal { get; set; }
        public int? IdFuente { get; set; }
        public int? clienteId { get; set; }
        public string clienteCodigo { get; set; }
        public string clienteNombre { get; set; }
        public string proveedorCodigo { get; set; }
        public string proveedorNombre { get; set; }
        public string fuente { get; set; }
        public int? IdBitacoraRegistro { get; set; }
        public string numeroEntrada { get; set; }
        public string facturaNumero { get; set; }
        public DateTime? facturaFecha { get; set; }
        public string registradoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? estatusId { get; set; }
        public string estatusDescripcion { get; set; }
        public int? tipoOperacionId { get; set; }
        public string tipoOperacionDescripcion { get; set; }
        public int? clavePedimentoId { get; set; }
        public string clavePedimentoDescripcion { get; set; }
        public int? zonaId { get; set; }
        public string zonaDescripcion { get; set; }
        public long totalPartidas { get; set; }
    }
}