namespace Exemplo.Core.Models.EstadosAdmissao
{
    public class EstadoAdmissaoFinalizada : EstadoAdmissaoBase
    {
        public override string Estado => "AdmissaoFinalizada";

        public override EstadoAdmissaoBase Aprovar()
        {
            System.Console.WriteLine($"Processo finalizado");
            return null;
        }

        public override EstadoAdmissaoBase Cancelar()
        {
            System.Console.WriteLine($"Processo cancelado");
            return new EstadoCancelado();
        }

        public override void Reprovar()
        {
            System.Console.WriteLine($"Processo reprovado");
        }
    }
}