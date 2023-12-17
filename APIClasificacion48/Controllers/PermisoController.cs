using APIClasificacion48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIClasificacion48.Controllers
{
    public class PermisoController : ApiController
    {
        private CnnDbContext _dbContext;

        public PermisoController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
        }

        // Obtiene todos los permisos de clasificación de partida
        [HttpGet]
        [Route("api/ClasificacionPartidaPermisos")]
        public IHttpActionResult Get()
        {
            var permisos = _dbContext.cdc_ClasificacionPartidaPermisos.ToList(); // Obtiene todos los permisos de clasificación de partida.
            return Ok(permisos); // Retorna una respuesta HTTP con los permisos obtenidos.
        }

        // Obtiene un permiso de clasificación de partida por su ID
        [HttpGet]
        [Route("api/ClasificacionPartidaPermisos/{id}")]
        public IHttpActionResult Get(int id)
        {
            var permisos = _dbContext.cdc_ClasificacionPartidaPermisos.Where(c => c.IdClasificacionPartida == id).ToList(); // Obtiene un permiso por su ID.
            if (permisos == null || !permisos.Any())
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si no se encuentra el permiso.
            }
            return Ok(permisos.Any() ? permisos : new List<cdc_ClasificacionPartidaPermisos>()); // Retorna una respuesta HTTP con el permiso encontrado o una lista vacía.
        }

        // Crea un nuevo permiso de clasificación de partida
        [HttpPost]
        [Route("api/ClasificacionPartidaPermisos")]
        public IHttpActionResult Post(cdc_ClasificacionPartidaPermisos nuevoPermiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos de permiso de partida no válidos."); // Retorna una respuesta HTTP 400 si los datos no son válidos.
            }

            _dbContext.cdc_ClasificacionPartidaPermisos.Add(nuevoPermiso); // Agrega un nuevo permiso a la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Permiso de partida creado correctamente."); // Retorna una respuesta HTTP indicando que el permiso se creó con éxito.
        }

        // Actualiza un permiso de clasificación de partida por su ID
        [HttpPut]
        [Route("api/ClasificacionPartidaPermisos/{id}")]
        public IHttpActionResult Put(int id, cdc_ClasificacionPartidaPermisos permisoActualizado)
        {
            var existingPermiso = _dbContext.cdc_ClasificacionPartidaPermisos.FirstOrDefault(p => p.Id == id); // Busca un permiso existente por su ID.
            if (existingPermiso == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si el permiso no existe.
            }

            // Actualiza los campos del permiso existente con los datos proporcionados.
            existingPermiso.Clave = permisoActualizado.Clave;
            existingPermiso.FirmaDescargo = permisoActualizado.FirmaDescargo;
            existingPermiso.NumeroPermiso = permisoActualizado.NumeroPermiso;
            existingPermiso.ValorComercialDolares = permisoActualizado.ValorComercialDolares;
            existingPermiso.CantidadMercancia = permisoActualizado.CantidadMercancia;

            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Permiso de partida actualizado correctamente."); // Retorna una respuesta HTTP indicando que el permiso se actualizó con éxito.
        }

        // Elimina un permiso de clasificación de partida por su ID
        [HttpDelete]
        [Route("api/ClasificacionPartidaPermisos/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var permiso = _dbContext.cdc_ClasificacionPartidaPermisos.FirstOrDefault(p => p.Id == id); // Busca un permiso por su ID.
            if (permiso == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si el permiso no existe.
            }

            _dbContext.cdc_ClasificacionPartidaPermisos.Remove(permiso); // Elimina el permiso de la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Permiso de partida eliminado correctamente."); // Retorna una respuesta HTTP indicando que el permiso se eliminó con éxito.
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose(); // Libera los recursos del contexto de base de datos al destruir el controlador.
            }
            base.Dispose(disposing);
        }
    }
}
