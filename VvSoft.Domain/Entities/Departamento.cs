using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VvSoft.Domain.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
