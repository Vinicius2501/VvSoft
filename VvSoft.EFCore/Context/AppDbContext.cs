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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(builder =>
            {
                builder.ToTable("Departamentos");

                builder.HasKey(d => d.DepartamentoId);

                builder.Property(d => d.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

                builder.Property(d => d.Descricao)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            }

            );
                
        }
    }
}
