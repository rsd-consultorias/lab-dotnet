using Exemplo.Core.DTO;

namespace Exemplo.Core.Models.EstadosAdmissao
{
    public abstract class EstadoAdmissaoBase
    {
        protected ProcessoAdmissao processoAdmissao;
        public void setProcessoAdmissao(ProcessoAdmissao processoAdmissao)
        {
            this.processoAdmissao = processoAdmissao;
        }

        public abstract EstadoAdmissaoBase Aprovar();
        public abstract void Reprovar();
        public abstract EstadoAdmissaoBase Cancelar();
        public abstract string Estado { get; }
    }
}