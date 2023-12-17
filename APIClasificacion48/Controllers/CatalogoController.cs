using APIClasificacion48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;

namespace APIClasificacion48.Controllers
{
    public class CatalogoController : ApiController
    {
        private CnnDbContext _dbContext;

        public CatalogoController()
        {
            _dbContext = new CnnDbContext(); // Inicialización del contexto de la base de datos al crear una instancia del controlador.
        }

        // Obtiene todos los elementos de un catálogo.
        public IHttpActionResult Get()
        {
            var catalogos = _dbContext.Set<_Catalogos>().ToList();
            return Ok(catalogos);
        }

        // Obtiene un elemento específico del catálogo por su ID.
        public IHttpActionResult Get(int id)
        {
            var catalogo = _dbContext.Set<_Catalogos>().FirstOrDefault(c => c.Id == id);
            if (catalogo == null)
                return NotFound();

            return Ok(catalogo);
        }

        // Obtiene elementos del catálogo filtrados por un estado específico.
        public IHttpActionResult Get(string status)
        {
            const string fixedStatus = "CDCESTATUS";
            if (status != fixedStatus)
            {
                return BadRequest("El parámetro status debe ser igual a 'CDCESTATUS'");
            }
            var catalogo = _dbContext._Catalogos.Where(r => r.Tipo == status).ToList();
            if (catalogo == null)
            {
                return NotFound();
            }
            return Ok(catalogo);
        }

        // Obtiene zonas con formato específico de ID y texto.
        [Route("api/Catalogo/GetZonas")]
        [HttpGet]
        public IHttpActionResult GetZonas()
        {
            const string fixedStatus = "Zona";
            var catalogo = _dbContext._Catalogos
                .Where(r => r.Tipo == fixedStatus)
                .Select(r => new { id = r.Id, text = r.Codigo + " - " + r.ValorTexto })
                .ToList();

            if (catalogo == null)
            {
                return NotFound();
            }

            return Ok(catalogo);
        }

        // Obtiene claves con formato de ID y texto.
        [Route("api/Catalogo/GetClaves")]
        [HttpGet]
        public IHttpActionResult GetClaves()
        {
            const string fixedStatus = "ClavesPedimentos";
            var catalogo = _dbContext._Catalogos
                .Where(r => r.Tipo == fixedStatus)
                .Select(r => new { id = r.Id, text = r.ValorTexto })
                .ToList();

            if (catalogo == null)
            {
                return NotFound();
            }

            return Ok(catalogo);
        }

        // Obtiene todos los elementos de la tabla de países.
        [Route("api/Catalogo/GetPaises")]
        [HttpGet]
        public IHttpActionResult GetPaises()
        {
            var catalogos = _dbContext.Set<_paises>().ToList();
            return Ok(catalogos);
        }

        // Obtiene operaciones específicas con formato de ID y texto.
        [Route("api/Catalogo/GetOperaciones")]
        [HttpGet]
        public IHttpActionResult GetOperaciones()
        {
            var tiposOperacion = new List<string> { "1", "2" };

            var catalogo = _dbContext._Catalogos
                .Where(r => r.Tipo == "TIPOOPERACION" && tiposOperacion.Contains(r.Codigo))
                .Select(r => new { id = r.Id, text = r.ValorTexto })
                .ToList();

            if (catalogo == null || !catalogo.Any())
            {
                return NotFound();
            }

            return Ok(catalogo);
        }

        // Obtiene unidades de medida de comercio con formato específico.
        [Route("api/Catalogo/GetUMC")]
        [HttpGet]
        public IHttpActionResult GetUMC()
        {
            const string fixedStatus = "UMC";
            var catalogo = _dbContext._UnidadesMedida.Where(r => r.Tipo == fixedStatus).ToList();
            if (catalogo == null)
            {
                return NotFound();
            }
            return Ok(catalogo);
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
