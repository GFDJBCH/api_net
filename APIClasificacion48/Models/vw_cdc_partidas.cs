using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class vw_cdc_partidas
    {
        public int id { get; set; }
        public int? clasificacion_id { get; set; }
        public string clasificacion_fuente { get; set; }
        public int? partida_id { get; set; }
        public int? partida_factura_id { get; set; }
        public string partida_guia { get; set; }
        public string partida_cliente_referencia { get; set; }
        public int? partida_parte_id { get; set; }
        public string partida_parte_numero { get; set; }
        public string partida_descripcion { get; set; }
        public int? partida_cantidad_unidad { get; set; }
        public int? partida_umc_id { get; set; }
        public string partida_umc_unidad { get; set; }
        public string partida_umc_descripcion { get; set; }
        public string partida_umc_descripcion_ingles { get; set; }
        public decimal? partida_peso_neto { get; set; }
        public int? partida_peso_neto_id { get; set; }
        public string partida_peso_neto_unidad { get; set; }
        public string partida_peso_neto_descripcion { get; set; }
        public string partida_peso_neto_descripcion_ingles { get; set; }
        public string partida_marca { get; set; }
        public string partida_modelo { get; set; }
        public int? partida_fraccion_id { get; set; }
        public string partida_pais { get; set; }
        public int? partida_usuario_reviso { get; set; }
        public string partida_estado { get; set; }
        public DateTime? partida_enviado { get; set; }
        public string partida_notas { get; set; }
        public int? partida_bitacora_id { get; set; }
        public string partida_fotos { get; set; }
        public int? partida_pais_vendedor_id { get; set; }
        public string partida_pais_vendedor_codigo { get; set; }
        public string partida_pais_vendedor_codigo2 { get; set; }
        public string partida_pais_vendedor_numerico { get; set; }
        public string partida_pais_vendedor_nombre { get; set; }
        public string partida_pais_vendedor { get; set; }
        public int? partida_pais_origen_id { get; set; }
        public string partida_pais_origen_codigo { get; set; }
        public string partida_pais_origen_codigo2 { get; set; }
        public string partida_pais_origen_numerico { get; set; }
        public string partida_pais_origen_nombre { get; set; }
        public int? partida_cantidad_factura { get; set; }
        public decimal? partida_peso_pieza { get; set; }
        public decimal? partida_costo_partida { get; set; }
        public decimal? partida_costo_unitario { get; set; }
        public decimal? partida_valor_agregado { get; set; }
        public int? partida_umf_id { get; set; }
        public string partida_umf_unidad { get; set; }
        public string partida_umf_descripcion { get; set; }
        public string partida_umf_descripcion_ingles { get; set; }
        public int? partida_umt_id { get; set; }
        public string partida_umt_unidad { get; set; }
        public string partida_umt_descripcion { get; set; }
        public string partida_umt_descripcion_ingles { get; set; }
        public decimal? partida_cantidad_tarifa { get; set; }
        public decimal? partida_peso_bruto { get; set; }
        public decimal? partida_cantidad_comercial { get; set; }
        public string partida_submodelo { get; set; }
        public int? partida_orden { get; set; }
        public decimal? partida_valor_unitario { get; set; }
        public decimal? partida_valor_total { get; set; }
        public bool? partida_madera { get; set; }
        public int? clasificacion_fraccion_id { get; set; }
        public string clasificacion_fraccion_numero { get; set; }
        public string umt_codigo { get; set; }
        public string clasificacion_descripcion { get; set; }
    }
}