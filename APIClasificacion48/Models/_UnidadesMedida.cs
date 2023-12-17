using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClasificacion48.Models
{
    public class _UnidadesMedida
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionIngles { get; set; }
        public bool Activo { get; set; }
        public int IdBitacoraRegistro { get; set; }
    }

}