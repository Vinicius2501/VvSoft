using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VvSoft.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateOnly DataContratacao { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public FuncionarioDetalhe? FuncionarioDetalhe { get; set; }
        public ICollection<FuncionarioProjeto> FuncionarioProjetos { get; set; } = new List<FuncionarioProjeto>();
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizandoEm { get; set; }
    }
}
