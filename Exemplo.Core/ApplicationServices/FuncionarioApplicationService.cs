using Exemplo.Core.Builders;
using Exemplo.Core.DTO;
using Exemplo.Core.Interfaces;
using Exemplo.Core.Models;

namespace Exemplo.Core.ApplicationServices
{
    public sealed class FuncionarioApplicationService
    {
        private IFuncionarioRepository funcionarioRepository;
        private IComunicacaoService comunicaoService;
        private IAntecedentesService antecedentesService;
        private IADService aDService;

        public FuncionarioApplicationService(
            IFuncionarioRepository funcionarioRepository,
            IComunicacaoService comunicaoService,
            IAntecedentesService antecedentesService,
            IADService aDService)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.comunicaoService = comunicaoService;
            this.antecedentesService = antecedentesService;
            this.aDService = aDService;
        }

        public ApplicationResponse<Funcionario> admitirFuncionario(PessoaDTO pessoa)
        {
            // INFO: usar uma resposta padronizada para os application services ajuda automatizar os testes
            var response = new ApplicationResponse<Funcionario>();
            if (this.antecedentesService.temAntecedentesGraves(pessoa))
            {
                response.sucesso = false;
                response.Mensagens.Add("Candidato inadimissível devido antecedentes graves.");
                return response;
            }

            var novoFuncionario = FuncionarioBuilder.BuildNovoFuncionario(pessoa.Nome, pessoa.CPF);
            novoFuncionario.Usuario = this.aDService.criarUsuario(novoFuncionario);

            if (novoFuncionario.ehValido())
            {
                /** TODO: evitar esse tipo de situação, se todo o processo estiver correto, não deveria
                * perder uma transação por causa de problema de infra. Nesse caso, deve-se pensar em uma
                * solução resiliente, como colocar numa fila, por exemplo.
                */
                if (this.funcionarioRepository.inserir(novoFuncionario))
                {
                    response.resultado = novoFuncionario;
                    response.sucesso = true;
                    this.comunicaoService.comunicarBoasVindas(novoFuncionario);
                }
                else
                {
                    response.sucesso = false;
                    response.Mensagens.Add("Funcionário não criado.");
                }
            }
            else
            {
                response.sucesso = false;
                response.Mensagens.Add("Cadastro inválido.");
            }

            return response;
        }
    }
}