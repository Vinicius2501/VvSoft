using Microsoft.EntityFrameworkCore;
using VvSoft.Domain.Entities;
using VvSoft.Domain.Entities.Enums;
using VvSoft.EFCore;

namespace VvSoft.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<FuncionarioProjeto> FuncionarioProjetos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

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

                builder.Property(d => d.AtualizadoEm)
                .HasDefaultValueSql("GETDATE()");

                builder.HasData(
                        new Departamento { DepartamentoId = 1, Nome = "Financeiro", Descricao = "Gestão de finanças" },
                        new Departamento { DepartamentoId = 2, Nome = "Marketing", Descricao = "Promoção de produtos" },
                        new Departamento { DepartamentoId = 3, Nome = "RH", Descricao = "Recursos Humanos" },
                        new Departamento { DepartamentoId = 4, Nome = "Suporte", Descricao = "Atendimento ao cliente" },
                        new Departamento { DepartamentoId = 5, Nome = "TI", Descricao = "Tecnologia e Informação" },
                        new Departamento { DepartamentoId = 6, Nome = "Vendas", Descricao = "Gestão de vendas" }
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

                builder.Property(f => f.Salario)
                .HasColumnType("decimal(10,2)");

                builder.Property(f => f.CriadoEm)
                .HasDefaultValueSql("GETDATE()");

                builder.Property(f => f.AtualizandoEm)
                .HasDefaultValueSql("GETDATE()");


                builder.HasData(
                    //Funcionários do Financeiro
                    new Funcionario { FuncionarioId = 1, Nome = "João Silva", Cargo = "Gerente de Finanças", Salario = 5250.00m ,DataContratacao = new DateOnly(2023,01,15),DepartamentoId = 1 },
                    new Funcionario { FuncionarioId = 2, Nome = "Carlos Pereira", Cargo = "Analista Financeiro", Salario = 4500.00m,DataContratacao = new DateOnly(2021,11,10),DepartamentoId = 1 },
                    new Funcionario { FuncionarioId = 3, Nome = "Ana Souza", Cargo = "Analista Comercial", Salario = 4300.00m,DataContratacao = new DateOnly(2022,02,15),DepartamentoId = 1 },
                    new Funcionario { FuncionarioId = 4, Nome = "Marcos Lima", Cargo = "Assistente Financeiro", Salario = 3200.00m,DataContratacao = new DateOnly(2022,05,20),DepartamentoId = 1 },
                    new Funcionario { FuncionarioId = 5, Nome = "Fernanda Oliveira", Cargo = "Coordenadora Financeiro", Salario = 4800.00m, DataContratacao = new DateOnly(2023,04,05), DepartamentoId = 1 },
                    new Funcionario { FuncionarioId = 6, Nome = "José Santos", Cargo = "Técnico em Contabilidade", Salario = 3400.00m, DataContratacao = new DateOnly(2023,07,18), DepartamentoId = 1 },

                    //Funcionários do Marketing
                    new Funcionario { FuncionarioId = 7, Nome = "Lucia Benitez", Cargo = "Coordenadora de Marketing", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 2 },
                    new Funcionario { FuncionarioId = 8, Nome = "Pedro Cardoso", Cargo = "Analsita de Marketing", Salario = 4100.00m, DataContratacao = new DateOnly(2022, 08, 22), DepartamentoId = 2 },
                    new Funcionario { FuncionarioId = 9, Nome = "Carla Teixeira", Cargo = "Especialista em SEO", Salario = 3900.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoId = 2 },
                    new Funcionario { FuncionarioId = 10, Nome = "Fabiana Costa", Cargo = "Gerente de Marketing", Salario = 5100.00m, DataContratacao = new DateOnly(2023, 03, 01), DepartamentoId = 2 },

                    //Funcionários do RH
                    new Funcionario { FuncionarioId = 11, Nome = "Roberto Ferreira", Cargo = "Analista de Recursos Humanos", Salario = 4400.00m, DataContratacao = new DateOnly(2021, 09, 20), DepartamentoId = 3 },
                    new Funcionario { FuncionarioId = 12, Nome = "Beatriz Almeida", Cargo = "Gerente de Recursos Humanos", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 03, 10), DepartamentoId = 3 },
                    new Funcionario { FuncionarioId = 13, Nome = "Lucas Santos", Cargo = "Coordenador de Recursos Humanos", Salario = 4600.00m, DataContratacao = new DateOnly(2022, 07, 15), DepartamentoId = 3 },
                    new Funcionario { FuncionarioId = 14, Nome = "Mariana Dias", Cargo = "Assistentes de Recursos Humanos", Salario = 3200.00m, DataContratacao = new DateOnly(2023, 05, 05), DepartamentoId = 3 },

                    //Funcionários do Suporte
                    new Funcionario { FuncionarioId = 15, Nome = "Juliana Mendes", Cargo = "Analista de Suporte", Salario = 3600.00m, DataContratacao = new DateOnly(2022, 06, 15), DepartamentoId = 4 },
                    new Funcionario { FuncionarioId = 16, Nome = "Rafael Souza", Cargo = "Técnico de Suporte", Salario = 3400.00m, DataContratacao = new DateOnly(2022, 08, 22), DepartamentoId = 4 },
                    new Funcionario { FuncionarioId = 17, Nome = "André Oliveira", Cargo = "Especialista em Suporte", Salario = 3800.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoId = 4 },
                    new Funcionario { FuncionarioId = 18, Nome = "Bruno Costa", Cargo = "Coordenador de Suporte", Salario = 4000.00m, DataContratacao = new DateOnly(2023, 01, 01), DepartamentoId = 4 },
                    new Funcionario { FuncionarioId = 19, Nome = "Aline Dias", Cargo = "Assistentes de Suporte", Salario = 3200.00m, DataContratacao = new DateOnly(2023, 03, 10), DepartamentoId = 4 },

                    //Funcionários do TI
                    new Funcionario { FuncionarioId = 20, Nome = "Fernando Carvalho", Cargo = "Analista de TI", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 5 },
                    new Funcionario { FuncionarioId = 21, Nome = "Gustavo Almeida", Cargo = "Desenvolvedor de Sistemas", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 02, 15), DepartamentoId = 5 },
                    new Funcionario { FuncionarioId = 22, Nome = "Renata Silva", Cargo = "Coordenadora de TI", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 05, 20), DepartamentoId = 5 },
                    new Funcionario { FuncionarioId = 23, Nome = "Thiago Souza", Cargo = "Técnico de Redes", Salario = 3600.00m, DataContratacao = new DateOnly(2023, 04, 05), DepartamentoId = 5 },
                    new Funcionario { FuncionarioId = 24, Nome = "Vanessa Oliveira", Cargo = "Engenheira de Software", Salario = 5200.00m, DataContratacao = new DateOnly(2023, 07, 18), DepartamentoId = 5 },
                    new Funcionario { FuncionarioId = 25, Nome = "Leonardo Pereira", Cargo = "Especialista em Segurança", Salario = 5500.00m, DataContratacao = new DateOnly(2023, 08, 01), DepartamentoId = 5 },

                    //Funcionários do Vendas
                    new Funcionario { FuncionarioId = 26, Nome = "Marta Carvalho", Cargo = "Gerente de Vendas", Salario = 5200.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoId = 6 },
                    new Funcionario { FuncionarioId = 27, Nome = "Ricardo Pereira", Cargo = "Representante de Vendas", Salario = 4500.00m, DataContratacao = new DateOnly(2022, 02, 15), DepartamentoId = 6 },
                    new Funcionario { FuncionarioId = 28, Nome = "Patrícia Santos", Cargo = "Assistente de Vendas", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 05, 20), DepartamentoId = 6 },
                    new Funcionario { FuncionarioId = 29, Nome = "Alberto Lima", Cargo = "Coordenador de Vendas", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 07, 18), DepartamentoId = 6 },
                    new Funcionario { FuncionarioId = 30, Nome = "Bianca Souza", Cargo = "Especialista em Vendas", Salario = 5000.00m, DataContratacao = new DateOnly(2023, 03, 05), DepartamentoId = 6 },
                    new Funcionario { FuncionarioId = 31, Nome = "Rogério Oliveira", Cargo = "Consultor de Vendas", Salario = 4700.00m, DataContratacao = new DateOnly(2023, 06, 10), DepartamentoId = 6 },
                    new Funcionario { FuncionarioId = 32, Nome = "Sofia Almeida", Cargo = "Técnico de Vendas", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 09, 01), DepartamentoId = 6 }

                    );
            }
            );

            modelBuilder.Entity<FuncionarioDetalhe>(builder =>
            {
                builder.Property(fd => fd.EnderecoResidencial)
                .HasMaxLength(200)
                .IsRequired();

                builder.Property(fd => fd.Celular)
                .HasMaxLength(25)
                .IsRequired();

                builder.Property(fd => fd.Foto)
                .HasMaxLength(200)
                .IsRequired();

                builder.Property(fd => fd.CPF)
                .HasMaxLength(20)
                .IsRequired();

                builder.Property(fd => fd.Nacionalidade)
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(fd => fd.Genero)
                .IsRequired();

                builder.Property(fd => fd.EstadoCivil)
                .IsRequired();

                builder.Property(fd => fd.Escolaridade)
                .IsRequired();

                builder.Property(f => f.CriadoEm)
                .HasDefaultValueSql("GETDATE()");

                builder.Property(f => f.AtualizandoEm)
                .HasDefaultValueSql("GETDATE()");

                builder.HasData(
                     new FuncionarioDetalhe { FuncionarioDetalheId = 1, FuncionarioId = 1, EnderecoResidencial = "Rua A, 123", DataNascimento = new DateTime(1990, 5, 10), Celular = "999999999", Genero = Genero.Masculino, Foto = "foto1.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "12345678901", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 2, FuncionarioId = 2, EnderecoResidencial = "Rua B, 234", DataNascimento = new DateTime(1988, 11, 20), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto2.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "23456789012", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 3, FuncionarioId = 3, EnderecoResidencial = "Rua C, 345", DataNascimento = new DateTime(1992, 8, 15), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto3.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "34567890123", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 4, FuncionarioId = 4, EnderecoResidencial = "Rua D, 456", DataNascimento = new DateTime(1985, 2, 25), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto4.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "45678901234", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 5, FuncionarioId = 5, EnderecoResidencial = "Rua E, 567", DataNascimento = new DateTime(1994, 3, 5), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto5.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "56789012345", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 6, FuncionarioId = 6, EnderecoResidencial = "Rua F, 678", DataNascimento = new DateTime(1989, 12, 15), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto6.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "67890123456", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },

                     new FuncionarioDetalhe { FuncionarioDetalheId = 7, FuncionarioId = 7, EnderecoResidencial = "Rua G, 789", DataNascimento = new DateTime(1991, 7, 21), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto7.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "78901234567", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 8, FuncionarioId = 8, EnderecoResidencial = "Rua H, 890", DataNascimento = new DateTime(1986, 4, 14), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto8.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "89012345678", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 9, FuncionarioId = 9, EnderecoResidencial = "Rua I, 901", DataNascimento = new DateTime(1993, 9, 12), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto9.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "90123456789", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 10, FuncionarioId = 10, EnderecoResidencial = "Rua J, 101", DataNascimento = new DateTime(1995, 11, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto10.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "01234567890", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

                     new FuncionarioDetalhe { FuncionarioDetalheId = 11, FuncionarioId = 11, EnderecoResidencial = "Rua K, 111", DataNascimento = new DateTime(1987, 1, 22), Celular = "988888888", Genero = Genero.Feminino, Foto = "foto11.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11111111111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 12, FuncionarioId = 12, EnderecoResidencial = "Rua L, 121", DataNascimento = new DateTime(1990, 2, 2), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto12.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22222222222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 13, FuncionarioId = 13, EnderecoResidencial = "Rua M, 131", DataNascimento = new DateTime(1991, 3, 3), Celular = "966666666", Genero = Genero.Feminino, Foto = "foto13.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33333333333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 14, FuncionarioId = 14, EnderecoResidencial = "Rua N, 141", DataNascimento = new DateTime(1992, 4, 4), Celular = "955555555", Genero = Genero.Masculino, Foto = "foto14.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44444444444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 15, FuncionarioId = 15, EnderecoResidencial = "Rua O, 151", DataNascimento = new DateTime(1993, 5, 5), Celular = "944444444", Genero = Genero.Feminino, Foto = "foto15.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55555555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 16, FuncionarioId = 16, EnderecoResidencial = "Rua P, 161", DataNascimento = new DateTime(1994, 6, 6), Celular = "933333333", Genero = Genero.Masculino, Foto = "foto16.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66666666666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 17, FuncionarioId = 17, EnderecoResidencial = "Rua Q, 171", DataNascimento = new DateTime(1995, 7, 7), Celular = "922222222", Genero = Genero.Feminino, Foto = "foto17.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77777777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 18, FuncionarioId = 18, EnderecoResidencial = "Rua R, 181", DataNascimento = new DateTime(1996, 8, 8), Celular = "911111111", Genero = Genero.Masculino, Foto = "foto18.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88888888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 19, FuncionarioId = 19, EnderecoResidencial = "Rua S, 191", DataNascimento = new DateTime(1997, 9, 9), Celular = "900000000", Genero = Genero.Feminino, Foto = "foto19.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99999999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 20, FuncionarioId = 20, EnderecoResidencial = "Rua T, 201", DataNascimento = new DateTime(1988, 10, 10), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto20.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00000000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

                     new FuncionarioDetalhe { FuncionarioDetalheId = 21, FuncionarioId = 21, EnderecoResidencial = "Rua U, 211", DataNascimento = new DateTime(1989, 11, 11), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto21.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11112222222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 22, FuncionarioId = 22, EnderecoResidencial = "Rua V, 221", DataNascimento = new DateTime(1990, 12, 12), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto22.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22223333333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 23, FuncionarioId = 23, EnderecoResidencial = "Rua W, 231", DataNascimento = new DateTime(1991, 1, 13), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto23.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33334444444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 24, FuncionarioId = 24, EnderecoResidencial = "Rua X, 241", DataNascimento = new DateTime(1992, 2, 14), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto24.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44445555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 25, FuncionarioId = 25, EnderecoResidencial = "Rua Y, 251", DataNascimento = new DateTime(1993, 3, 15), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto25.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556666666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 26, FuncionarioId = 26, EnderecoResidencial = "Rua Z, 261", DataNascimento = new DateTime(1994, 4, 16), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto26.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66667777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 27, FuncionarioId = 27, EnderecoResidencial = "Rua AA, 271", DataNascimento = new DateTime(1995, 5, 17), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto27.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77778888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 28, FuncionarioId = 28, EnderecoResidencial = "Rua AB, 281", DataNascimento = new DateTime(1996, 6, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto28.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88889999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },

                     new FuncionarioDetalhe { FuncionarioDetalheId = 29, FuncionarioId = 29, EnderecoResidencial = "Rua AC, 291", DataNascimento = new DateTime(1997, 7, 19), Celular = "988888888", Genero = Genero.Feminino, Foto = "foto29.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 30, FuncionarioId = 30, EnderecoResidencial = "Rua AD, 291", DataNascimento = new DateTime(1998, 7, 19), Celular = "988778888", Genero = Genero.Feminino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000002", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 31, FuncionarioId = 31, EnderecoResidencial = "Rua AJ, 291", DataNascimento = new DateTime(1998, 11, 9), Celular = "988778866", Genero = Genero.Feminino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "99990000001", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                     new FuncionarioDetalhe { FuncionarioDetalheId = 32, FuncionarioId = 32, EnderecoResidencial = "Rua AD, 301", DataNascimento = new DateTime(1988, 8, 20), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00001111111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio });
                }
            );

            modelBuilder.Entity<Projeto>(builder => 
                {
                    builder.Property(p => p.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

                    builder.Property(p => p.Descricao)
                    .HasMaxLength(200)
                    .IsRequired();

                    builder.Property(p => p.Orcamento)
                    .HasColumnType("decimal(20,2)")
                    .IsRequired();
                }
            );

            modelBuilder.Entity<FuncionarioProjeto>().HasKey(fp => new { fp.FuncionarioId, fp.ProjetoId });

            modelBuilder.Entity<Cliente>(builder =>
                {
                    builder.Property(c => c.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

                    builder.Property(c => c.Email)
                    .HasMaxLength(200)
                    .IsRequired();

                    builder.Property(c => c.Telefone)
                    .HasMaxLength(50)
                    .IsRequired();

                    builder.Property(c => c.CriadoEm)
                    .HasDefaultValueSql("GETDATE()");

                    builder.Property(c => c.AtualizadoEm)
                    .HasDefaultValueSql("GETDATE()");

                    builder.HasData(
                        new Cliente { ClienteId = 1, Nome = "Grupo ABroad SA", Email = "abroad@email.com", Telefone = "55-11 99980-0099"},
                        new Cliente { ClienteId = 2, Nome = "Construtora ABC", Email = "abcconstru@email.com", Telefone = "55-31 98957-1022"},
                        new Cliente { ClienteId = 3, Nome = "EduFuture Corp.", Email = "edufuture@email.com", Telefone = "55-11 98750-4422"},
                        new Cliente { ClienteId = 4, Nome = "Tech Innovators Ltda", Email = "innovators@email.com", Telefone = "55-11 99950-9622"},
                        new Cliente { ClienteId = 5, Nome = "Health Solutions Inc.", Email = "healthsolutions@email.com", Telefone = "55-21 99852-9655"}

                    );
                }
            );

        }
    }
}
