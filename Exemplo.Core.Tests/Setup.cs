using Exemplo.Core.DTO;
using Exemplo.Core.Interfaces;
using Models;

namespace Exemplo.Core.Tests
{
    public static class Constantes
    {
        public static string CPF_ANTECEDENTES_GRAVES = "99999999999";
    }
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public bool inserir(Funcionario funcionario)
        {
            return true;
        }
    }

    public class AntecedentesService : IAntecedentesService
    {
        public bool temAntecedentesGraves(PessoaDTO pessoa)
        {
            return pessoa.CPF.Equals(Constantes.CPF_ANTECEDENTES_GRAVES);
        }
    }

    public class ComunicacaoService : IComunicacaoService
    {
        public void comunicarBoasVindas(Funcionario funcionario)
        { }
    }

    public class ADService : IADService
    {
        public string criarUsuario(Funcionario pessoa)
        {
            return $"u{pessoa.Nome.Substring(0, 3).ToLower()}";
        }
    }
}