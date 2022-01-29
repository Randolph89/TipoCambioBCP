using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.CrossCutting.Dto
{
    public class TipoCambioCalculadoDto
    {
        public Decimal ValorTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public Decimal Monto { get; set; }
        public Decimal MontoCalculado { get; set; }
    }
}
