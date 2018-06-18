using Bolao.Aplicacao.Interfaces.ServicosExternos;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosExternos;
using System.Collections.Generic;

namespace Bolao.Aplicacao.ServicosExternos
{
    public class GravatarServicosExternos : IGravatarServicosExternos
    {
        private readonly string _urlBase = "https://www.gravatar.com";

        private readonly IRestSharpClient _restSharp;

        public GravatarServicosExternos(IRestSharpClient restSharp)
        {
            _restSharp = restSharp;
        }

        public string Avatar(string hash, string tamanho)
        {
            var resource = $"/avatar/{hash}";
            Dictionary<string, string> parametros = null;
            if (tamanho != null)
            {
                parametros = new Dictionary<string, string>
                {
                    { "s", tamanho }
                };
            }
            return _restSharp.Get(_urlBase, resource, parametros).Content;
        }
    }
}
