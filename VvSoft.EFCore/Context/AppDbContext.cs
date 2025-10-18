using Microsoft.EntityFrameworkCore;
using VvSoft.Domain.Entities;
using VvSoft.EFCore;

namespace VvSoft.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnection());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VvSoft");

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

                builder.Property(d => d.CriadoEm)
                .HasDefaultValueSql("GETDATE()");

                builder.HasData(
                        new Departamento { DepartamentoId = 1, Nome = "Desenvolvimento", Descricao = "Desenvolvimento de Projetos" },
                        new Departamento { DepartamentoId = 2, Nome = "Financeiro", Descricao = "Gestão de finanças" },
                        new Departamento { DepartamentoId = 3, Nome = "Marketing", Descricao = "Promoção de produtos" },
                        new Departamento { DepartamentoId = 4, Nome = "Recursos Humanos", Descricao = "Recursos Humanos" },
                        new Departamento { DepartamentoId = 5, Nome = "Suporte", Descricao = "Atendimento ao cliente" }

                    );

                }
            );

            modelBuilder.Entity<Funcionario>(builder =>
            {
                builder.ToTable("Funcionarios");

                builder.HasKey(f => f.FuncionarioId);

                builder.Property(f => f.Nome)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

                builder.Property(f => f.Cargo)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

                builder.Property(f => f.CriadoEm)
                .HasDefaultValueSql("GETDATE()");

                builder.Property(f => f.AtualizandoEm)
                .HasDefaultValueSql("GETDATE()");
            }
            );
        }
    }
}
