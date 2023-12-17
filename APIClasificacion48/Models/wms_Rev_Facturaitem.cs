using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class wms_Rev_Facturaitem
    {
        public int id { get; set; }
        public int IdFactura { get; set; }
        public string Guia { get; set; }
        public string ReferenciaCliente { get; set; }
        public string NoParte { get; set; }
        public string Descripcion { get; set; }
        public int? CantidadUnidad { get; set; }
        public int? IdUnidadMedidaComercial { get; set; }
        public decimal? PesoNeto { get; set; }
        public int? IdUnidadPesoNeto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? IdFraccionArancelaria { get; set; }
        public string Pais { get; set; }
        public int? IdUsuarioReviso { get; set; }
        public string Estatus { get; set; }
        public DateTime? FechaHoraEnviado { get; set; }
        public string Notas { get; set; }
        public int? idBitacoraRegistro { get; set; }
        public string Fotos { get; set; }
        public string PaisVendedor { get; set; }
        public int? IdPaisOrigen { get; set; }
        public int? IdPaisVendedor { get; set; }
        public int? CantidadFactura { get; set; }
        public decimal? PesoPieza { get; set; }
        public int? IdParte { get; set; }
        public decimal? CostoPartida { get; set; }
        public decimal? CostoUnit { get; set; }
        public decimal? ValorAgregado { get; set; }
        public int? IdUnidadMedidaFacturaItem { get; set; }
        public decimal? CantidadTarifa { get; set; }
        public int? IdUnidadMedidaTarifa { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? CantidadComercial { get; set; }
        public string SubModelo { get; set; }
        public int? Orden { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? ValorTotal { get; set; }
        public bool? EmbalajeMadera { get; set; }
    }
}