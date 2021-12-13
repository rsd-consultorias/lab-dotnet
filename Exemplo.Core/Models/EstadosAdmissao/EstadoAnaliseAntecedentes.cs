namespace Exemplo.Core.Models.EstadosAdmissao
{
    public class EstadoAnaliseAntecedentes : EstadoAdmissaoBase
    {
        public override string Estado => "AnaliseAntecedentes";

        public override EstadoAdmissaoBase Aprovar()
        {
            System.Console.WriteLine($"Analise de antecedentes aprovado");
            return new EstadoAdmissaoFinalizada();
        }

        public override EstadoAdmissaoBase Cancelar()
        {
            System.Console.WriteLine($"Processo de admissão cancelado");
            return new EstadoCancelado();
        }

        public override void Reprovar()
        {
            System.Console.WriteLine($"Analise de antecedentes reprovado");
        }
    }
}