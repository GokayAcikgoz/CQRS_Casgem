using Microsoft.EntityFrameworkCore;

namespace CQRS_Casgem.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; " +
                "initial catalog = CasgemCQRSDb; integrated security = true");
        }


        public DbSet<Product> Products { get; set; }
    }
}
