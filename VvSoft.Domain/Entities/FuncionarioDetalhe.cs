using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VvSoft.Domain.Entities.Enums;

namespace VvSoft.Domain.Entities
{
    public class FuncionarioDetalhe
    {
        public int FuncionarioDetalheId { get; set; }
        public string? EnderecoResidencial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Celular { get; set; }
        public Genero Genero { get; set; }
        public string? Foto { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string? CPF { get; set; }
        public string? Nacionalidade { get; set; }
        public Escolaridade Escolaridade { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizandoEm { get; set; }

    }
}
