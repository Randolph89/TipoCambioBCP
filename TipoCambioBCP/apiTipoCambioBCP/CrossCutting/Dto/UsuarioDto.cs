using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.CrossCutting.Dto
{
    public class UsuarioDto
    {
        public string UsuarioId { get; set; }
        public string NombreUsu { get; set; }
        public string CorreoEletronico { get; set; }
        public string RolId { get; set; }
        public string NombreRol { get; set; }
    }
}
