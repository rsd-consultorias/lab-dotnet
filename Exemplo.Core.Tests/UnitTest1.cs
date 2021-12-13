using System;
using Exemplo.Core.ApplicationServices;
using Exemplo.Core.DTO;
using Exemplo.Core.Models;
using Exemplo.Core.Models.EstadosAdmissao;
using NUnit.Framework;

namespace Exemplo.Core.Tests
{
    public class Tests
    {
        private FuncionarioApplicationService funcionarioApplicationService;
        private static PessoaDTO pessoaComAntecendentesGraves;

        [SetUp]
        public void Setup()
        {
            this.funcionarioApplicationService = new FuncionarioApplicationService(
                new FuncionarioRepository(),
                new ComunicacaoService(),
                new AntecedentesService(),
                new ADService()
            );

            pessoaComAntecendentesGraves = new PessoaDTO()
            {
                CPF = Constantes.CPF_ANTECEDENTES_GRAVES,
                Nome = "Fulano de Tal",
                DataNascimento = new System.DateTime(1980, 1, 1)
            };
        }

        [Test]
        public void PessoaComAntecedenteGraveNaoPodeSerAdmitida()
        {
            var response = this.funcionarioApplicationService.admitirFuncionario(pessoaComAntecendentesGraves);

            Assert.False(response.sucesso, "Não pode admitir a pessoa");
            Assert.AreEqual(response.Mensagens[0], "Candidato inadimissível devido antecedentes graves.");
        }


        [Test]
        public void Teste()
        {
            var processo = new ProcessoAdmissao(pessoaComAntecendentesGraves, new EstadoIniciado());
            // Estado: Iniciado
            System.Console.WriteLine($"### Estado atual: {processo.Estado}");
            
            // Estado: AnaliseAntecedentes
            processo.Aprovar();
            System.Console.WriteLine($"### Estado atual: {processo.Estado}");

            // Estado: AdmissaoFinalizada
            processo.Aprovar();
            System.Console.WriteLine($"### Estado atual: {processo.Estado}");

        }
    }
}