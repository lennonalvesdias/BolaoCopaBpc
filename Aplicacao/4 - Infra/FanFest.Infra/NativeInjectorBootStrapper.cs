using AutoMapper;
using FanFest.Aplicacao.Interfaces.ServicosApp;
using FanFest.Aplicacao.ServicosApp;
using FanFest.Dados.Contexto;
using FanFest.Dados.Repositorios;
using FanFest.Dominio.Interfaces.Repositorios;
using FanFest.Dominio.Interfaces.Servicos;
using FanFest.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace FanFest.Infra
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
            services.AddScoped<FanFestContexto>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}