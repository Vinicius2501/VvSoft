using Microsoft.EntityFrameworkCore;
using VvSoft.Domain.Entities;
using VvSoft.EFCore;

namespace VvSoft.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnection());
        }
    }
}
