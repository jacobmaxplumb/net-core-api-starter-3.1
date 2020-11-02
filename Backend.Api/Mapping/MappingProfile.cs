using AutoMapper;
using Backend.Api.Resources;
using Backend.Core.Models;
using Backend.Core.Models.Auth;

namespace Backend.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Color, ColorResource>();
            // CreateMap<Artist, ArtistResource>();
            
            // Resource to Domain
            // CreateMap<MusicResource, Music>();
            CreateMap<SaveColorResource, Color>();
            // CreateMap<ArtistResource, Artist>();
            // CreateMap<SaveArtistResource, Artist>();
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}