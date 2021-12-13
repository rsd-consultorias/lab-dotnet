using System;
using Exemplo.Core.DTO;
using Exemplo.Core.Models.EstadosAdmissao;

namespace Exemplo.Core.Models
{
    public class ProcessoAdmissao
    {
        private EstadoAdmissaoBase estadoAdmissao;
        public string Id { get; set; }
        public PessoaDTO pessoa { get; private set; }
        public string Estado { get { return this.estadoAdmissao.Estado; } }

        public ProcessoAdmissao(PessoaDTO pessoa, EstadoAdmissaoBase estadoAdmissao)
        {
            this.pessoa = pessoa;
            this.estadoAdmissao = estadoAdmissao;
        }

        public void ProximoEstado(EstadoAdmissaoBase proximoEstado)
        {
            if (proximoEstado != null)
            {
                this.estadoAdmissao = proximoEstado;
                this.estadoAdmissao.setProcessoAdmissao(this);
            }
        }

        public void Aprovar()
        {
            this.ProximoEstado(this.estadoAdmissao.Aprovar());
        }

        public void Cancelar()
        {
            this.estadoAdmissao.Cancelar();
        }

        public void Reprovar()
        {
            this.estadoAdmissao.Reprovar();
        }
    }
}