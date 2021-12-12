using System.Collections.Generic;

namespace Exemplo.Core.DTO
{
    public sealed class ApplicationResponse<TModel>
    {
        public ApplicationResponse()
        {
            this.Mensagens = new List<string>();
        }
        public bool sucesso { get; set; }
        public TModel resultado { get; set; }
        public List<string> Mensagens { get; set; }
    }
}