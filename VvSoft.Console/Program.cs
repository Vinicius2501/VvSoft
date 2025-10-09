using VvSoft.Domain.Context;
using VvSoft.Domain.Entities;

using(AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando banco de dados \n");
    context.Database.EnsureCreated();

    Console.WriteLine("Criando base de departamento \n");
    CriarDepartamento(context);
    Console.WriteLine("Base de departamento criado");
}

Console.ReadKey();

void CriarDepartamento(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Desenvolvimento",
        Descricao = "Desenvolvimento de Projetos"
    };
    context.Departamentos.Add(departamento);
    context.SaveChanges();
}