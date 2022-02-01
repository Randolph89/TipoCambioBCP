using apiTipoCambioBCP.Context;
using apiTipoCambioBCP.CrossCutting.Dto;
using apiTipoCambioBCP.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TipoCambioController : ControllerBase
    {
        private TipoCambioDBContext _context;

        public TipoCambioController(TipoCambioDBContext context)
        {
            _context = context;
        }

        [HttpPost("Actualizar")]
        public async Task<ActionResult> Actualizar([FromBody] TipoCambioDto model)
        {
            var tipoCambio = new TipoCambio
            {
                ID = model.ID,
                MonedaOrigen = model.MonedaOrigen,
                MonedaDestino = model.MonedaDestino,
                ValorTipoCambio = model.ValorTipoCambio
            };

            _context.TipoCambio.Update(tipoCambio);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("ObtenerTipoCambio/{pMonto}/{pCodMonedaOrigen}/{pCodMonedaDestino}")]
        public async Task<ActionResult> ObtenerTipoCambio(decimal pMonto, string pCodMonedaOrigen, String pCodMonedaDestino)
        {
            if (pMonto > 0)
            {
                var tipoCambio = _context.TipoCambio.First(x => x.MonedaOrigen == pCodMonedaOrigen && x.MonedaDestino == pCodMonedaDestino);

                var montoCalculado = pMonto  / tipoCambio.ValorTipoCambio;

                var montoTipoCambioCalculado = new TipoCambioCalculadoDto
                {
                    Monto = Math.Round(pMonto,2),
                    MontoCalculado  = Math.Round(montoCalculado, 2),
                    MonedaDestino = pCodMonedaDestino,
                    MonedaOrigen = pCodMonedaOrigen,
                    ValorTipoCambio = Math.Round( tipoCambio.ValorTipoCambio,2)
                };
                return Ok(montoTipoCambioCalculado);

            }
             return BadRequest("El monto debe ser mayor de cero");

        }

        [HttpGet("Listar")]
        public async Task<ActionResult> Listar()
        {
            var tipoCambios = _context.TipoCambio.ToList();
            return Ok(tipoCambios);
        }
    }
}
