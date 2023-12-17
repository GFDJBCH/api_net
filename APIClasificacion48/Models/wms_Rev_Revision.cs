using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class wms_Rev_Revision
    {
        public int id { get; set; }
        public int? idSucursal { get; set; }
        public string Folio { get; set; }
        public DateTime FechaHora { get; set; }
        public int? IDCliente { get; set; }
        public int? IDTransportista { get; set; }
        public int? CantidadPallet { get; set; }
        public string Referencia { get; set; }
        public bool Urgente { get; set; }
        public string Notas { get; set; }
        public DateTime? FechaHoraEnviado { get; set; }
        public string Estatus { get; set; }
        public DateTime? FechaHoraEstatus { get; set; }
        public int? IdBitacoraRegistro { get; set; }
        public int Consecutivo { get; set; }
        public string Tipo { get; set; }
        public string NumeroEntrada { get; set; }
        public int? CantidadEmbalaje { get; set; }
        public int? IDUnidadBulto { get; set; }
        public int? IdRecinto { get; set; }
        public int? IdUnidadTransporte { get; set; }
        public decimal? PesoTotal { get; set; }
        public string GuiaPrevio { get; set; }
        public string ReferenciaTrafico { get; set; }
        public int? IdTipoCarga { get; set; }
        public int? IdTipoPrevio { get; set; }
        public DateTime? FechaCita { get; set; }
        public DateTime? FechaIniCita { get; set; }
        public DateTime? FechaFinCita { get; set; }
    }
}