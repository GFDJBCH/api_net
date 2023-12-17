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
    public class PartidaController : ApiController
    {
        private CnnDbContext _dbContext;

        public PartidaController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
        }

        // Obtiene todas las partidas por ID de clasificación
        [HttpGet]
        [Route("api/Partida/{clasificacionId}")]
        public IHttpActionResult GetPartidasPorClasificacionId(int clasificacionId)
        {
            var partidas = _dbContext.vw_cdc_partidas
                                   .Where(p => p.clasificacion_id == clasificacionId)
                                   .ToList(); // Obtiene las partidas por ID de clasificación.

            if (partidas == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si no se encuentran partidas.
            }

            return Ok(partidas.Any() ? partidas : new List<vw_cdc_partidas>()); // Retorna una respuesta HTTP con las partidas encontradas o una lista vacía.
        }

        // Obtiene una partida por su ID
        [HttpGet]
        [Route("api/Partida/GetPartidaPorId/{id}")]
        public IHttpActionResult GetPartidaPorId(int id)
        {
            var partida = _dbContext.vw_cdc_partidas.FirstOrDefault(p => p.id == id); // Obtiene una partida por su ID.

            if (partida == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si no se encuentra la partida.
            }

            return Ok(partida); // Retorna una respuesta HTTP con la partida encontrada.
        }

        // Crea una nueva clasificación de partida
        [HttpPost]
        [Route("api/ClasificacionPartida")]
        public IHttpActionResult Post(cdc_ClasificacionPartida clasificacionPartida)
        {
            // Validación de datos de clasificación de partida
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos de clasificación de partida no válidos."); // Retorna una respuesta HTTP 400 si los datos no son válidos.
            }

            // Verifica y ajusta el ID de fracción
            if (clasificacionPartida.IdFraccion == 0)
            {
                clasificacionPartida.IdFraccion = null;
            }

            _dbContext.cdc_ClasificacionPartida.Add(clasificacionPartida); // Agrega una nueva clasificación de partida a la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Clasificación de partida creada correctamente."); // Retorna una respuesta HTTP indicando que la clasificación se creó con éxito.
        }

        // Inserta una nueva partida
        [HttpPost]
        [Route("api/Partida/InsertarPartida")]
        public IHttpActionResult InsertarPartida(cdc_ClasificacionPartida nuevaPartida)
        {
            // Verifica si ya existe una partida con la misma descripción
            var existingPartida = _dbContext.cdc_ClasificacionPartida.FirstOrDefault(c => c.Descripcion == nuevaPartida.Descripcion);
            if (existingPartida != null)
            {
                return BadRequest("No se registró la partida debido a que la descripción ya existe en la base de datos."); // Retorna una respuesta HTTP 400 si la partida ya existe.
            }

            // Validación de datos de la nueva partida
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var serializedErrors = JsonConvert.SerializeObject(errors);
                return BadRequest(serializedErrors); // Retorna una respuesta HTTP 400 con los errores de validación.
            }

            _dbContext.cdc_ClasificacionPartida.Add(nuevaPartida); // Agrega la nueva partida a la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok(new { partidaId = nuevaPartida.Id }); // Retorna una respuesta HTTP con el ID de la nueva partida.
        }

        // Actualiza una partida por su ID
        [HttpPut]
        [Route("api/Partida/ActualizarPartida/{id}")]
        public IHttpActionResult ActualizarPartida(int id, cdc_ClasificacionPartida partidaActualizada)
        {
            // Validación de datos de la partida actualizada
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var serializedErrors = JsonConvert.SerializeObject(errors);
                return BadRequest(serializedErrors); // Retorna una respuesta HTTP 400 con los errores de validación.
            }

            // Verifica si el ID proporcionado en la URL coincide con el ID del objeto
            if (id != partidaActualizada.Id)
            {
                return BadRequest("El ID proporcionado en la URL no coincide con el ID proporcionado en el objeto."); // Retorna una respuesta HTTP 400 si los IDs no coinciden.
            }

            var existingPartida = _dbContext.cdc_ClasificacionPartida.FirstOrDefault(c => c.Id == id); // Busca la partida existente por su ID.
            if (existingPartida == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si la partida no existe.
            }

            // Actualiza los campos de la partida existente con los datos proporcionados
            existingPartida.IdClasificacion = partidaActualizada.IdClasificacion;
            existingPartida.IdFuentePartida = partidaActualizada.IdFuentePartida;
            existingPartida.Fuente = partidaActualizada.Fuente;
            existingPartida.Fraccion = partidaActualizada.Fraccion;
            existingPartida.UMT = partidaActualizada.UMT;
            existingPartida.IdFraccion = partidaActualizada.IdFraccion;
            existingPartida.Descripcion = partidaActualizada.Descripcion;

            try
            {
                _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.
                return Ok(new { partidaId = partidaActualizada.Id }); // Retorna una respuesta HTTP con el ID de la partida actualizada.
            }
            catch (Exception ex)
            {
                // Loguea el error ex
                return InternalServerError(ex); // Retorna una respuesta HTTP 500 en caso de error interno.
            }
        }

        // Elimina una partida por su ID
        [HttpDelete]
        [Route("api/Partida/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var partida = _dbContext.cdc_ClasificacionPartida.FirstOrDefault(p => p.Id == id); // Busca la partida por su ID.
            if (partida == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si la partida no existe.
            }

            _dbContext.cdc_ClasificacionPartida.Remove(partida); // Elimina la partida de la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok(new { status = "ok" }); // Retorna una respuesta HTTP indicando que la partida se eliminó con éxito.
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
