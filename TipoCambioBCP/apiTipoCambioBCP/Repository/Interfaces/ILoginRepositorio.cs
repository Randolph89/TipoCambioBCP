using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Repository.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia);
    }
}
