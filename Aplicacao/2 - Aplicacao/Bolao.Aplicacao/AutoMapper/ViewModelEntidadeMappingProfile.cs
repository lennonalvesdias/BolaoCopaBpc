using AutoMapper;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Entidades;

namespace Bolao.Aplicacao.AutoMapper
{
    public class ViewModelEntidadeMappingProfile : Profile
    {
        public ViewModelEntidadeMappingProfile()
        {
            CreateMap<UsuarioLoginViewModel, Usuario>();
            CreateMap<UsuarioSendViewModel, Usuario>();
        }
    }
}