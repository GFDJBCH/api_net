using APIClasificacion48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIClasificacion48.Controllers
{
    public class IdentificadorController : ApiController
    {
        private CnnDbContext _dbContext;

        public IdentificadorController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de base de datos al crear una instancia del controlador.
        }

        // Obtiene todos los identificadores de clasificación de partida
        [HttpGet]
        [Route("api/ClasificacionPartidaIdentificadores")]
        public IHttpActionResult Get()
        {
            var identificadores = _dbContext.cdc_ClasificacionPartidaIdentificadores.ToList(); // Obtiene todos los identificadores de clasificación de partida.
            return Ok(identificadores); // Retorna una respuesta HTTP con los identificadores obtenidos.
        }

        // Obtiene un identificador de clasificación de partida por su ID
        [HttpGet]
        [Route("api/ClasificacionPartidaIdentificadores/{id}")]
        public IHttpActionResult Get(int id)
        {
            var identificadores = _dbContext.cdc_ClasificacionPartidaIdentificadores.Where(c => c.IdClasificacionPartida == id).ToList(); // Obtiene un identificador por su ID.
            if (identificadores == null || !identificadores.Any())
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si no se encuentra el identificador.
            }
            return Ok(identificadores.Any() ? identificadores : new List<cdc_ClasificacionPartidaIdentificadores>()); // Retorna una respuesta HTTP con el identificador encontrado o una lista vacía.
        }

        // Crea un nuevo identificador de clasificación de partida
        [HttpPost]
        [Route("api/ClasificacionPartidaIdentificadores")]
        public IHttpActionResult Post(cdc_ClasificacionPartidaIdentificadores nuevoIdentificador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos de identificador de partida no válidos."); // Retorna una respuesta HTTP 400 si los datos no son válidos.
            }

            _dbContext.cdc_ClasificacionPartidaIdentificadores.Add(nuevoIdentificador); // Agrega un nuevo identificador a la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Identificador de partida creado correctamente."); // Retorna una respuesta HTTP indicando que el identificador se creó con éxito.
        }

        // Actualiza un identificador de clasificación de partida por su ID
        [HttpPut]
        [Route("api/ClasificacionPartidaIdentificadores/{id}")]
        public IHttpActionResult Put(int id, cdc_ClasificacionPartidaIdentificadores identificadorActualizado)
        {
            var existingIdentificador = _dbContext.cdc_ClasificacionPartidaIdentificadores.FirstOrDefault(c => c.Id == id); // Busca un identificador existente por su ID.
            if (existingIdentificador == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si el identificador no existe.
            }

            // Actualiza los campos del identificador existente con los datos proporcionados.
            existingIdentificador.Clave = identificadorActualizado.Clave;
            existingIdentificador.Complemento1 = identificadorActualizado.Complemento1;
            existingIdentificador.Complemento2 = identificadorActualizado.Complemento2;
            existingIdentificador.Complemento3 = identificadorActualizado.Complemento3;

            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Identificador de partida actualizado correctamente."); // Retorna una respuesta HTTP indicando que el identificador se actualizó con éxito.
        }

        // Elimina un identificador de clasificación de partida por su ID
        [HttpDelete]
        [Route("api/ClasificacionPartidaIdentificadores/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var identificador = _dbContext.cdc_ClasificacionPartidaIdentificadores.FirstOrDefault(c => c.Id == id); // Busca un identificador por su ID.
            if (identificador == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 si el identificador no existe.
            }

            _dbContext.cdc_ClasificacionPartidaIdentificadores.Remove(identificador); // Elimina el identificador de la base de datos.
            _dbContext.SaveChanges(); // Guarda los cambios en la base de datos.

            return Ok("Identificador de partida eliminado correctamente."); // Retorna una respuesta HTTP indicando que el identificador se eliminó con éxito.
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
