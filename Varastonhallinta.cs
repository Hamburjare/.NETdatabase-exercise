
using Microsoft.EntityFrameworkCore; // Tietokantaa varten
namespace Varastonhallinta
{
    public class StorageControl : DbContext
    {
        public DbSet<Varasto>? Tuotteet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
            "Initial Catalog=Varastonhallinta;" +
            "Integrated Security=true;" + 
            //"User Id = sa; " + "Password = salasana; " 
            "MultipleActiveResultSets=true;";
            // Tässä otetaan yhteys tietokantaan
            optionsBuilder.UseSqlServer(connection);
        }
    }
}