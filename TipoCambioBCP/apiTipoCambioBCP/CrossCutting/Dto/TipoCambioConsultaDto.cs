using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.CrossCutting.Dto
{
    public class TipoCambioConsultaDto
    {
        public int codMonedaOrigen { get; set; }
        public int codMonedaDestino { get; set; }
        public string desMonedaOrigen { get; set; }
        public string desMonedaDestino { get; set; }
        public decimal tipoCambio { get; set; }
        public decimal monto { get; set; }
    }
}
