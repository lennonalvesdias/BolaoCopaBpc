using AutoMapper;
using FanFest.Aplicacao.ViewModels;
using FanFest.Dominio.Entidades;

namespace FanFest.Aplicacao.AutoMapper
{
    public class ViewModelEntidadeMappingProfile : Profile
    {
        public ViewModelEntidadeMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<ReservarAlbumViewModel, Usuario>();
        }
    }
}