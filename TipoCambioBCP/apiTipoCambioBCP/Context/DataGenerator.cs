using apiTipoCambioBCP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TipoCambioDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<TipoCambioDBContext>>()))
            {
                // Look for any board games already in database.
                if (context.TipoCambio.Any())
                {
                    return;   // Database has been seeded
                }

                context.TipoCambio.AddRange(
                    new TipoCambio
                    {
                        MonedaOrigen = "PEN",
                        MonedaDestino = "USD",
                        ValorTipoCambio = Convert.ToDecimal(3.89),
                        FechaRegistro = DateTime.Now
                    },
                    new TipoCambio
                    {
                        MonedaOrigen = "PEN",
                        MonedaDestino = "EUR",
                        ValorTipoCambio = Convert.ToDecimal(4.56),
                        FechaRegistro = DateTime.Now
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
