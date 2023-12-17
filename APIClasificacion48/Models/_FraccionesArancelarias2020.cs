using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class _FraccionesArancelarias2020
    {
        [Key]
        public int idFraccion { get; set; }
        public string Fraccion { get; set; }
        public string DescEspanol { get; set; }
        public string AdvImpo { get; set; }
        public string AdvExpo { get; set; }
        public string UMT { get; set; }
        public string Pais { get; set; }
        public byte? Activo { get; set; }
    }
}