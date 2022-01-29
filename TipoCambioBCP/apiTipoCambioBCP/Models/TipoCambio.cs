using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Models
{
    public class TipoCambio
    {
        public int ID { get; set; }
        public Decimal ValorTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
