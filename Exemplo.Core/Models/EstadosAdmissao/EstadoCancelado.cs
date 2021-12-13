namespace Exemplo.Core.Models.EstadosAdmissao
{
    public class EstadoCancelado : EstadoAdmissaoBase
    {
        public override string Estado => "AnaliseAntecedentes";

        public override EstadoAdmissaoBase Aprovar()
        {
            throw new System.Exception("Não é possível cancelar um processo já cancelado");
        }

        public override EstadoAdmissaoBase Cancelar()
        {
            throw new System.Exception("Não é possível cancelar um processo já cancelado");
        }

        public override void Reprovar()
        {
            throw new System.Exception("Não é possível cancelar um processo já cancelado");
        }
    }
}