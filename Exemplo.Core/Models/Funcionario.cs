using System;
using Exemplo.Core.ValueObjects;

namespace Exemplo.Core.Models
{
    public class Funcionario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Usuario { get; set; }
        public EnderecoVO Endereco { get; set; }
        public string EMail { get; set; }
        public bool ehValido()
        {
            // Validar CPF
            return this.CPF.Length == 11;
        }
    }
}