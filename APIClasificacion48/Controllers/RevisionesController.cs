using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using APIClasificacion48.Models;
using Newtonsoft.Json.Linq;

public class RevisionesController : ApiController
{
    private CnnDbContext _dbContext;

    public RevisionesController()
    {
        _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
    }

    // Obtiene todas las revisiones.
    [HttpGet]
    [Route("api/Revisiones")]
    public IHttpActionResult Get()
    {
        var revisiones = _dbContext.Set<vw_wms_revision>().ToList();

        // Retorna una respuesta con datos y metadatos para compatibilidad con DataTables.
        return Ok(new
        {
            draw = 0, // Número de veces que se ha dibujado la tabla (para paginación en DataTables).
            recordsTotal = revisiones.Count(), // Total de registros sin filtrar.
            recordsFiltered = revisiones.Count(), // Total de registros después de aplicar filtros (igual a recordsTotal en este caso).
            data = revisiones // Datos de las revisiones obtenidas.
        });
    }

    // Obtiene una revisión por su ID.
    [HttpGet]
    [Route("api/Revisiones/{id}")]
    public IHttpActionResult Get(int id)
    {
        var revision = _dbContext.Set<wms_Rev_Revision>().FirstOrDefault(r => r.id == id);
        if (revision == null)
            return NotFound();

        return Ok(revision);
    }

    // Obtiene revisiones por estatus.
    [HttpGet]
    [Route("api/Revisiones/GetPorEstatus")]
    public IHttpActionResult Get(string estatus)
    {
        var revisiones = _dbContext.wms_Rev_Revision.Where(r => r.Estatus == estatus).ToList();
        if (revisiones == null)
            return NotFound();

        return Ok(revisiones);
    }

    // Obtiene los items de factura por revisión.
    [HttpGet]
    [Route("api/Revisiones/GetFacturaItemsPorRevision/{idRevision}")]
    public IHttpActionResult GetFacturaItemsPorRevision(int idRevision)
    {
        var facturas = _dbContext.Set<wms_Rev_Factura>()
                                .Where(f => f.IDReferencia == idRevision)
                                .Select(f => f.id)
                                .ToList();

        var facturaItems = _dbContext.Set<wms_Rev_Facturaitem>()
                                    .Where(fi => facturas.Contains(fi.IdFactura))
                                    .ToList();

        if (facturaItems.Count == 0)
        {
            return NotFound();
        }

        return Ok(facturaItems);
    }

    // Obtiene las sucursales asociadas a las revisiones.
    [Route("api/Revisiones/GetSucursales")]
    [HttpGet]
    public IHttpActionResult GetSucursales()
    {
        var sucursales = _dbContext.vw_wms_revision
                              .Where(s => s.sucursal_id != null)
                              .GroupBy(s => s.sucursal_id)
                              .Select(g => new
                              {
                                  id = g.Key,
                                  text = g.FirstOrDefault().sucursal_codigo,
                                  descripcion = g.FirstOrDefault().sucursal_descripcion
                              })
                              .ToList();

        return Ok(sucursales);
    }

    // Libera los recursos del contexto de base de datos al destruir el controlador.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _dbContext.Dispose();

        base.Dispose(disposing);
    }
}
