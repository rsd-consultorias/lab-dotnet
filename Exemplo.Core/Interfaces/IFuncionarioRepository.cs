using Models;

namespace Exemplo.Core.Interfaces
{
    public interface IFuncionarioRepository {
        bool inserir(Funcionario funcionario);
    }
}