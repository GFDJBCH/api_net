using APIClasificacion48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIClasificacion48.Controllers
{
    public class FraccionController : ApiController
    {
        private CnnDbContext _dbContext;

        public FraccionController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
        }

        // Obtiene todas las fracciones arancelarias del año 2020.
        [HttpGet]
        [Route("api/Fracciones")]
        public IHttpActionResult Get()
        {
            var fracciones = _dbContext.Set<_FraccionesArancelarias2020>().ToList();

            // Retorna una respuesta con datos y metadatos para compatibilidad con DataTables.
            return Ok(new
            {
                draw = 0, // Número de veces que se ha dibujado la tabla (para paginación en DataTables).
                recordsTotal = fracciones.Count(), // Total de registros sin filtrar.
                recordsFiltered = fracciones.Count(), // Total de registros después de aplicar filtros (igual a recordsTotal en este caso).
                data = fracciones // Datos de las fracciones arancelarias.
            });
        }

        // Libera los recursos del contexto de base de datos al destruir el controlador.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();

            base.Dispose(disposing);
        }
    }
}
