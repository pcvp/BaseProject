using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Zaion.Auth.Data.Dtos.Usuario;
using Zaion.Auth.Models;

namespace Zaion.Auth.Profiles {
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
