using Microsoft.EntityFrameworkCore;

namespace apiTipoCambioBCP.Context
{
    public class TipoCambioDBContext : DbContext
    {
        public TipoCambioDBContext(DbContextOptions<TipoCambioDBContext> options)
    : base(options)
        {
        }

        public DbSet<Models.TipoCambio> TipoCambio { get; set; }
    }
}
