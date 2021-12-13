namespace Exemplo.Core.Models.EstadosAdmissao
{
    public class EstadoIniciado : EstadoAdmissaoBase
    {
        public override string Estado => "Iniciado";

        public override EstadoAdmissaoBase Aprovar()
        {
            System.Console.WriteLine($"Processo iniciado");
            return new EstadoAnaliseAntecedentes();
        }

        public override EstadoAdmissaoBase Cancelar()
        {
            throw new System.Exception("Não é possível cancelar um processo ainda não iniciado");
        }

        public override void Reprovar()
        {
            throw new System.Exception("Não é possível reprovar um processo ainda não iniciado");
        }
    }
}