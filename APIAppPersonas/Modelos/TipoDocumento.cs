using System;
using System.Collections.Generic;

#nullable disable

namespace APIAppPersonas.Modelos
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            PersonaJuridicas = new HashSet<PersonaJuridica>();
            PersonaNaturals = new HashSet<PersonaNatural>();
        }

        public int IdTipoDocumento { get; set; }
        public string NombreDocumento { get; set; }

        public virtual ICollection<PersonaJuridica> PersonaJuridicas { get; set; }
        public virtual ICollection<PersonaNatural> PersonaNaturals { get; set; }
    }
}
