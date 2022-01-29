using apiTipoCambioBCP.CrossCutting.Entities;
using apiTipoCambioBCP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Repository.Repositories
{
    public class LoginRepositorio : ILoginRepositorio
    {
        public async Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia)
        {
            var vContrasenia = (pContrasenia);

            var oUsuarioAutentificado = new UsuarioBe()
            {
                UsuarioId = pUsuarioId,
                NombreRol = "RolAdministrador",
                NombreUsu = "Usuario Administrador",
                RolId = "1",
                CorreoEletronico = "randolph.2r@gmail.com"
            };

            return oUsuarioAutentificado;
        }
    }
}
