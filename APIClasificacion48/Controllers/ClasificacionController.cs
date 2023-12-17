using APIClasificacion48.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIClasificacion48.Controllers
{
    public class ClasificacionController : ApiController
    {
        private readonly CnnDbContext _dbContext;

        public ClasificacionController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
        }

        // Obtiene todos los elementos de la tabla de clasificaciones.
        public IHttpActionResult Get()
        {
            var clasificaciones = _dbContext.vw_cdc_clasificacion.ToList();
            return Ok(clasificaciones);
        }

        // Obtiene un elemento de la tabla de clasificaciones por su ID.
        public IHttpActionResult Get(int id)
        {
            var clasificacion = _dbContext.vw_cdc_clasificacion.FirstOrDefault(c => c.id == id);
            if (clasificacion == null)
                return NotFound();

            return Ok(clasificacion);
        }

        // Obtiene elementos de la tabla de clasificaciones filtrados por descripción de estatus.
        public IHttpActionResult Get(string estatus)
        {
            var revisiones = _dbContext.vw_cdc_clasificacion.Where(r => r.estatusDescripcion == estatus).ToList();
            if (revisiones == null)
                return NotFound();

            return Ok(revisiones);
        }

        // Agrega una nueva clasificación a la base de datos.
        public IHttpActionResult Post(cdc_Clasificacion clasificacion)
        {
            var existingClasificacion = _dbContext.cdc_Clasificacion.FirstOrDefault(c => c.Referencia == clasificacion.Referencia);
            if (existingClasificacion != null)
            {
                return BadRequest("No se registró la clasificación debido a que la referencia ya existe en la base de datos.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var serializedErrors = JsonConvert.SerializeObject(errors);
                return BadRequest(serializedErrors);
            }

            _dbContext.cdc_Clasificacion.Add(clasificacion);
            _dbContext.SaveChanges();

            return Ok(new { clasificacionId = clasificacion.Id });
        }

        // Actualiza una clasificación existente por su ID.
        public IHttpActionResult Put(int id, vw_cdc_clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos de clasificación no válidos.");

            var clasifExistente = _dbContext.vw_cdc_clasificacion.FirstOrDefault(c => c.id == id);
            if (clasifExistente == null)
                return NotFound();

            clasifExistente = clasificacion;
            _dbContext.SaveChanges();

            return Ok("Clasificación actualizada correctamente.");
        }

        // Actualiza el estado de una clasificación por su ID.
        [HttpPut]
        [Route("api/Clasificacion/ActualizarEstado/{id}/{nuevoEstadoId}")]
        public IHttpActionResult ActualizarEstado(int id, int nuevoEstadoId)
        {
            var clasificacion = _dbContext.cdc_Clasificacion.FirstOrDefault(c => c.Id == id);

            if (clasificacion == null)
            {
                return NotFound();
            }

            if (nuevoEstadoId == 3347)
            {
                clasificacion.IdEstatus = 3348;
            }
            else
            {
                clasificacion.IdEstatus = nuevoEstadoId;
            }

            _dbContext.SaveChanges();

            return Ok(new { status = "ok" });
        }

        // Elimina una clasificación por su ID.
        public IHttpActionResult Delete(int id)
        {
            var clasificacion = _dbContext.vw_cdc_clasificacion.FirstOrDefault(c => c.id == id);
            if (clasificacion == null)
                return NotFound();

            _dbContext.vw_cdc_clasificacion.Remove(clasificacion);
            _dbContext.SaveChanges();

            return Ok("Clasificación eliminada correctamente.");
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
