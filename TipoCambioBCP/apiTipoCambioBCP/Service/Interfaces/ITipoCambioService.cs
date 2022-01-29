using apiTipoCambioBCP.CrossCutting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Service.Interfaces
{
    public interface ITipoCambioService
    {
        Task<List<TipoCambioDto>> GetTipoCambio(int pCodMoneda);
    }
}
