using apiTipoCambioBCP.Repository.Interfaces;
using apiTipoCambioBCP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Service.Implementatios
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepositorio _iRepositorio;
        public LoginService(ILoginRepositorio pIRepositorio)
        {
            this._iRepositorio = pIRepositorio;
        }
        public async Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia)
        {
            return await _iRepositorio.GetLogin(pUsuarioId, pContrasenia);
        }
    }
}
