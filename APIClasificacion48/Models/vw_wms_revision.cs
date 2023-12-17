using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class vw_wms_revision
    {
        public int id { get; set; }
        public int? sucursal_id { get; set; }
        public string sucursal_codigo { get; set; }
        public string sucursal_descripcion { get; set; }
        public string Folio { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? cliente_id { get; set; }
        public string cliente_codigo { get; set; }
        public string cliente_id_fiscal { get; set; }
        public string cliente_nombre { get; set; }
        public string cliente_razon { get; set; }
        public bool? cliente_estado { get; set; }
        public int? transportista_id { get; set; }
        public string transportista_codigo { get; set; }
        public string transportista_id_fiscal { get; set; }
        public string transportista_nombre { get; set; }
        public string transportista_razon { get; set; }
        public bool? transportista_estado { get; set; }
        public int? CantidadPallet { get; set; }
        public string Referencia { get; set; }
        public bool? Urgente { get; set; }
        public string Notas { get; set; }
        public DateTime? FechaHoraEnviado { get; set; }
        public string Estatus { get; set; }
        public DateTime? FechaHoraEstatus { get; set; }
        public int? bitacora_id { get; set; }
        public string bitacora_creo_nombre { get; set; }
        public string bitacora_actualizo_nombre { get; set; }
        public string bitacora_elimino_nombre { get; set; }
        public int? Consecutivo { get; set; }
        public string Tipo { get; set; }
        public string NumeroEntrada { get; set; }
        public int? CantidadEmbalaje { get; set; }
        public int? unidad_bulto_id { get; set; }
        public string unidad_bulto_tipo { get; set; }
        public string unidad_bulto_unidad { get; set; }
        public string unidad_bulto_descripcion { get; set; }
        public string unidad_bulto_descripcion_ingles { get; set; }
        public bool? unidad_estado { get; set; }
        public int? recinto_id { get; set; }
        public int? recinto_clave { get; set; }
        public string recinto_nombre { get; set; }
        public int? unidad_transporte_id { get; set; }
        public string unidad_transporte_nombre { get; set; }
        public decimal? PesoTotal { get; set; }
        public string GuiaPrevio { get; set; }
        public string ReferenciaTrafico { get; set; }
    }
}