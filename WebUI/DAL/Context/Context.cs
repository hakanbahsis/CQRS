using Microsoft.EntityFrameworkCore;

namespace WebUI.DAL.Context
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-PK98KLS;initial catalog=CasgemDbCQRS;integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }


    }
}
