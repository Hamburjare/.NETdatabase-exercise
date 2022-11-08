
using Microsoft.EntityFrameworkCore; // Tietokantaa varten
namespace Varastonhallinta
{
    public class StorageControl : DbContext
    {
        public DbSet<Varasto>? Tuotteet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // string connection = "Data Source=.;" +
            // "Initial Catalog=Varastonhallinta;" +
            // "Integrated Security=true;" + 
            // "User Id = sa; " + "Password = salasana; " +
            // "MultipleActiveResultSets=true;";
            string connection = $"Data Source=.; Initial Catalog=Varastonhallinta; Integrated Security=FALSE; User Id = sa; Password = pX45@x65f4LX?tjb;";
            // Tässä otetaan yhteys tietokantaan
            optionsBuilder.UseSqlServer(connection);

        }
    }
}