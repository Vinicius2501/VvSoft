using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VvSoft.Domain.Entities.Enums;

namespace VvSoft.Domain.Entities
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public Decimal Orcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataFim {  get; set; }
        public StatusProjeto Status { get; set; }
        public ICollection<FuncionarioProjeto> FuncionarioProjetos { get; set; } = new List<FuncionarioProjeto>();
        public int ClientId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
