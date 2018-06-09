using AutoMapper;
using FanFest.Aplicacao.ViewModels;
using FanFest.Dominio.Entidades;

namespace FanFest.Aplicacao.AutoMapper
{
    public class EntidadeViewModelMappingProfile : Profile
    {
        public EntidadeViewModelMappingProfile() 
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}