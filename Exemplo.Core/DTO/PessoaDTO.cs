using System;

namespace Exemplo.Core.DTO
{
    public struct PessoaDTO {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}