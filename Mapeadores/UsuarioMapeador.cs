using AutoMapper;
using CrudUsuarioBackend.DTO;
using CrudUsuarioBackend.Entidades;

namespace CrudUsuarioBackend.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
