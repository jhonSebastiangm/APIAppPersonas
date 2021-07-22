using System;
using System.Collections.Generic;

#nullable disable

namespace APIAppPersonas.Modelos
{
    public partial class PersonaJuridica
    {
        public int Nit { get; set; }
        public int? Identificacion { get; set; }
        public string RazonSocial { get; set; }
        public int? TipoPersonaId { get; set; }
        public string Via { get; set; }
        public int? Nro1 { get; set; }
        public string Letra1 { get; set; }
        public int? Nro2 { get; set; }
        public string Letra2 { get; set; }
        public string NroAndComplements { get; set; }
        public string Municipio { get; set; }
        public string Telefono { get; set; }

        public virtual PersonaNatural IdentificacionNavigation { get; set; }
        public virtual TipoDocumento TipoPersona { get; set; }
    }
}
