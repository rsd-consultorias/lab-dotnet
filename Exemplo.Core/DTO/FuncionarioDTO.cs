using System;

namespace Exemplo.Core.DTO
{
    public struct FuncionarioDTO {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Usuario { get; set; }
        public string EMail { get; set; }
    }
}