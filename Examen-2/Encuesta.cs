using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2
{
    public partial class Encuesta
    {
        public int NumeroEncuesta { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public string Genero {  get; set; }
       
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public bool TieneCarro { get; set; }
        public string IdentificacionCarro { get; set; }
        public bool TieneMoto { get; set; }
        public string IdentificacionMoto { get; set; }
        public bool TieneBici { get; set; }
        public string IdentificacionBici { get; set; }

        // Constructor
        public Encuesta()
        {
            // Inicializamos las propiedades
            this.NumeroEncuesta = 0;
            this.Nombre = "";
            this.Apellido1 = "";
            this.Apellido2 = "";
            this.FechaNacimiento = DateTime.Now;
            this.Edad = 0;
            this.Genero = "";
            this.Cedula = "";
            this.Correo = "";
            this.TieneCarro = false;
            this.IdentificacionCarro = "";
            this.TieneMoto = false;
            this.IdentificacionMoto = "";
            this.TieneBici = false;
            this.IdentificacionBici = "";
        }
    }
}