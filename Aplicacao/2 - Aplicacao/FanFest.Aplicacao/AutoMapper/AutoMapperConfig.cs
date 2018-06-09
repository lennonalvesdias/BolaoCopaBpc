using AutoMapper;

namespace FanFest.Aplicacao.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntidadeViewModelMappingProfile());
                cfg.AddProfile(new ViewModelEntidadeMappingProfile());
            });
        }
    }
}