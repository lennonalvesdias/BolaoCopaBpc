using AutoMapper;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.Interfaces.ServicosExternos;
using Bolao.Aplicacao.ServicosApp;
using Bolao.Aplicacao.ServicosExternos;
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
            services.AddScoped<IPalpiteServicosApp, PalpiteServicosApp>();
            services.AddScoped<IEquipeServicosApp, EquipeServicosApp>();
            services.AddScoped<IRankingServicosApp, RankingServicosApp>();
            services.AddScoped<IResultadoServicosApp, ResultadoServicosApp>();
            services.AddScoped<ITabelaServicosApp, TabelaServicosApp>();
            services.AddScoped<IAuditoriaServicosApp, AuditoriaServicosApp>();

            services.AddScoped<IFootballDataServicosExternos, FootballDataServicosExternos>();

            // Dominio
            services.AddScoped<IUsuarioServicos, UsuarioServicos>();
            services.AddScoped<IPalpiteServicos, PalpiteServicos>();

            // Infra
            services.AddScoped<BolaoContexto>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPalpiteRepositorio, PalpiteRepositorio>();
        }
    }
}