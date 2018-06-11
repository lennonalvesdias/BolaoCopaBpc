using AutoMapper;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Entidades;

namespace Bolao.Aplicacao.AutoMapper
{
    public class EntidadeViewModelMappingProfile : Profile
    {
        public EntidadeViewModelMappingProfile() 
        {
            CreateMap<Usuario, UsuarioReturnViewModel>();
            CreateMap<Palpite, PalpiteReturnViewModel>();
            CreateMap<Resultado, ResultadoReturnViewModel>();
        }
    }
}