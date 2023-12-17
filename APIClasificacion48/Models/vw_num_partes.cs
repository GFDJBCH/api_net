using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class vw_num_partes
    {
        [Key]
        public int parte_id { get; set; }
        public int? cliente_id { get; set; }
        public int? proveedor_id { get; set; }
        public string proveedor_codigo { get; set; }
        public string proveedor_nombre { get; set; }
        public string parte_numero { get; set; }
        public string parte_descripcion { get; set; }
        public int? fraccion_id { get; set; }
        public string fraccion_numero { get; set; }
        public string fraccion_descripcion { get; set; }
        public int? fraccion_pais_id { get; set; }
        public string fraccion_pais_codigo { get; set; }
        public string fraccion_pais_codigo2 { get; set; }
        public string fraccion_pais_numerico { get; set; }
        public string fraccion_pais_nombre { get; set; }
        public int? fraccion_unidad_medida { get; set; }
        public int? hts_id { get; set; }
        public string hts_numero { get; set; }
        public string hts_descripcion { get; set; }
        public int? hts_pais_id { get; set; }
        public string hts_pais_codigo { get; set; }
        public string hts_pais_codigo2 { get; set; }
        public string hts_pais_numerico { get; set; }
        public string hts_pais_nombre { get; set; }
        public int? hts_unidad_medida { get; set; }
        public int? parte_unidad_medida_id { get; set; }
        public string parte_unidad_medida_tipo { get; set; }
        public string parte_unidad_medida_unidad { get; set; }
        public string parte_unidad_medida_descripcion { get; set; }
        public string parte_unidad_medida_desc_ingles { get; set; }
        public float? FactorConversionBulto { get; set; }
        public int? bulto_unidad_medida_id { get; set; }
        public string bulto_unidad_medida_tipo { get; set; }
        public string bulto_unidad_medida_unidad { get; set; }
        public string bulto_unidad_medida_descripcion { get; set; }
        public float? FactorConversionPallet { get; set; }
        public int? cove_unidad_medida_id { get; set; }
        public string cove_unidad_medida_tipo { get; set; }
        public string cove_unidad_medida_unidad { get; set; }
        public string cove_unidad_medida_descripcion { get; set; }
        public float? FactorConversionCove { get; set; }
        public float? PesoBrutoUnitario { get; set; }
        public float? PesoNetoUnitario { get; set; }
        public int? peso_unidad_medida_id { get; set; }
        public string peso_unidad_medida_tipo { get; set; }
        public string peso_unidad_medida_unidad { get; set; }
        public string peso_unidad_medida_descripcion { get; set; }
        public decimal? ImporteUnitario { get; set; }
        public decimal? Importe { get; set; }
        public string Notas { get; set; }
        public int? Activo { get; set; }
        public int? IdBitacoraRegistros { get; set; }
        public int? pais_origen_id { get; set; }
        public string pais_origen_codigo { get; set; }
        public string pais_origen_codigo2 { get; set; }
        public string pais_origen_numerico { get; set; }
        public string pais_origen_nombre { get; set; }
        public int? pais_vendedor_id { get; set; }
        public string pais_vendedor_codigo { get; set; }
        public string pais_vendedor_codigo2 { get; set; }
        public string pais_vendedor_numerico { get; set; }
        public string pais_vendedor_nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Fraccion { get; set; }
    }
}