using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Service.Interfaces
{
    public interface ILoginService
    {
        Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia);
    }
}
