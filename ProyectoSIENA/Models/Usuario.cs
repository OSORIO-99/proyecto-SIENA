using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSIENA.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Documento es obligatorio")]
        [RegularExpression("[0123456789]", ErrorMessage = "Solo puede ingresar números")]
        public long Documento { get; set; }


        public string Tipodoc { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        public string Celular { get; set; }

        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string Email { get; set; }

        [RegularExpression("[FfMm]", ErrorMessage = "Solo puede ingresar F o M")]
        public string Genero { get; set; }

        public string Aprendiz { get; set; }

        public string Egresado { get; set; }

        public string AreaFormacion { get; set; }

        public string FechaEgresado { get; set; }

        public string Direccion { get; set; }

        public string Barrio { get; set; }

        public string Ciudad { get; set; }

        public string Departamento { get; set; }

        public string FechaRegistro { get; set; }

    }
}