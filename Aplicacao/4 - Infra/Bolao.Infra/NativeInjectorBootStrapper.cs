using AutoMapper;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ServicosApp;
using Bolao.Dados.Contexto;
using Bolao.Dados.Repositorios;
using Bolao.Dominio.Interfaces.Repositorios;
using Bolao.Dominio.Interfaces.Servicos;
using Bolao.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Bolao.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Aplicacao
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IUsuarioServicosApp, UsuarioServicosApp>();

            // Dominio
            services.AddScoped<IUsuarioServicos, UsuarioServicos>();

            // Infra
            services.AddScoped<BolaoContexto>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}