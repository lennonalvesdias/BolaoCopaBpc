using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosExternos
{
    public interface IFootballDataServicosExternos
    {
        string Get(string resource, IDictionary<string, string> parameters = null);
    }
}
