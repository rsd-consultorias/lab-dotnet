using Models;

namespace Exemplo.Core.Builders
{
    public static class FuncionarioBuilder
    {
        public static Funcionario BuildNovoFuncionario(string nome, string cpf)
        {
            var novoFuncionario = new Funcionario();
            novoFuncionario.Nome = nome;
            novoFuncionario.CPF = cpf;

            return novoFuncionario;
        }
    }
}