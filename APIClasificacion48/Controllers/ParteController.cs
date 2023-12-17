using APIClasificacion48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIClasificacion48.Controllers
{
    public class ParteController : ApiController
    {
        private CnnDbContext _dbContext;

        public ParteController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
        }

        // Obtiene todas las partes o partes de un cliente específico según el ID del cliente proporcionado.
        [HttpGet]
        [Route("api/Partes")]
        public IHttpActionResult Get(int cliente_id = 0)
        {
            IQueryable<vw_num_partes> partesQuery = _dbContext.Set<vw_num_partes>();

            // Filtra las partes por cliente si se proporciona un ID de cliente válido.
            if (cliente_id != 0)
            {
                partesQuery = partesQuery.Where(p => p.cliente_id == cliente_id);
            }

            var partes = partesQuery.ToList();

            // Retorna una respuesta con datos y metadatos para compatibilidad con DataTables.
            return Ok(new
            {
                draw = 0, // Número de veces que se ha dibujado la tabla (para paginación en DataTables).
                recordsTotal = partes.Count(), // Total de registros sin filtrar.
                recordsFiltered = partes.Count(), // Total de registros después de aplicar filtros (igual a recordsTotal en este caso).
                data = partes // Datos de las partes obtenidas.
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
