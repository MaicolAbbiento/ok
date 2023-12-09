using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ok.Models
{
    public partial class Model : DbContext
    {
        public virtual DbSet<Appunti> Appunti { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source =.\\SQLEXPRESS; initial catalog = core; TrustServerCertificate = True; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework");
            }
        }
    }
}