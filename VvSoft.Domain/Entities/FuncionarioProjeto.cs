using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VvSoft.Domain.Entities
{
    public class FuncionarioProjeto
    {
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public int HorasTrabalhadas { get; set; }
    }
}
