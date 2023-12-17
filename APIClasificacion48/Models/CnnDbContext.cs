using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class CnnDbContext: DbContext
    {
        public CnnDbContext() : base("cnnDataBase")
        {
        }
        public DbSet<wms_Rev_Factura> wms_Rev_Factura { get; set; }
        public DbSet<wms_Rev_Facturaitem> wms_Rev_FacturaItem { get; set; }
        public DbSet<vw_wms_revision> vw_wms_revision { get; set; }
        public DbSet<wms_Rev_Revision> wms_Rev_Revision { get; set; }
        public DbSet<cdc_Clasificacion> cdc_Clasificacion { get; set; }
        public DbSet<cdc_ClasificacionPartida> cdc_ClasificacionPartida { get; set; }
        public DbSet<cdc_ClasificacionPartidaPermisos> cdc_ClasificacionPartidaPermisos { get; set; }
        public DbSet<cdc_ClasificacionPartidaIdentificadores> cdc_ClasificacionPartidaIdentificadores { get; set; }
        public DbSet<vw_cdc_partidas> vw_cdc_partidas { get; set; }
        public DbSet<vw_cdc_clasificacion> vw_cdc_clasificacion { get; set; }
        public DbSet<_Catalogos> _Catalogos { get; set; }
        public DbSet<_UnidadesMedida> _UnidadesMedida { get; set; }
        public DbSet<_paises> _paises { get; set; }
        public DbSet<_FraccionesArancelarias2020> _FraccionesArancelarias2020 { get; set; }
        public DbSet<vw_num_partes> vw_num_partes { get; set; }

    }
}