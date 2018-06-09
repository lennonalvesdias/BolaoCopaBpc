using System;
using System.IO;
using System.Linq;
using AutoMapper;
using FanFest.Aplicacao.ViewModels;
using FanFest.Dados.Contexto;
using FanFest.Dominio.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using MongoDB.Driver;
using System.Collections.Generic;

namespace FanFest.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            var login = new Login();
            services.AddSingleton(login);

            var token = new Token();
            new ConfigureFromConfigurationOptions<Token>(Configuration.GetSection("TokenConfigurations")).Configure(token);
            services.AddSingleton(token);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearer =>
            {
                var paramsValidation = bearer.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = login.Chave;
                paramsValidation.ValidAudience = token.Publico;
                paramsValidation.ValidIssuer = token.Emissor;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("V1", new Info
                {
                    Title = "FanFest Marília",
                    Version = "v1",
                    Description = "",
                    TermsOfService = "...",
                    Contact = new Contact { Name = "Lennon V. Alves Dias", Email = "lennonalvesdias@gmail.com", Url = "http://www.lennonalves.com.br" },
                    License = new License { Name = "", Url = "" }
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                };

                var apiKeyScheme = new ApiKeyScheme
                {
                    Description = "JWT Bearer Authentication",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                };

                s.AddSecurityDefinition("Bearer", apiKeyScheme);
                s.AddSecurityRequirement(security);
            });

            BaseContexto.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            BaseContexto.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            BaseContexto.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);

            services.AddMvc();

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Swagger/V1/swagger.json", "V1 Docs");
                c.DocumentTitle = "Documentation";
                c.DocExpansion(DocExpansion.None);
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var FanFestContextService = serviceScope.ServiceProvider.GetRequiredService<FanFestContexto>();
                var admin = FanFestContextService.Usuarios.Find(x => x.Apelido == "lennonalvesdias").FirstOrDefault();
                if (admin == null)
                {
                    var lennonalvesdias = new Usuario("lennonalvesdias", "FanFestMarilia@2006", 0);
                    FanFestContextService.Usuarios.InsertOne(lennonalvesdias);
                }
            }
        }

        private static void RegisterServices(IServiceCollection services)
        {
            Infra.NativeInjectorBootStrapper.RegisterServices(services);
            RecursosCompartilhados.Infra.NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
