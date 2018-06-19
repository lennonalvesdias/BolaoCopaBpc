using System;

namespace Bolao.Aplicacao
{
    public class Helpers
    {
        public static int GetIdByHref(string href)
        {
            var lastIndexOfHref = href.LastIndexOf("/");
            var codigo = href.Substring(lastIndexOfHref + 1, (href.Length - lastIndexOfHref) - 1);
            return Convert.ToInt32(codigo);
        }
    }
}
