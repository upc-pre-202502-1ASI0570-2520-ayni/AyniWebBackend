using AutoMapper;
using AyniWebBackend.Security.Domain.Models;
using AyniWebBackend.Security.Domain.Services.Communication;
using AyniWebBackend.Security.Resources;

namespace AyniWebBackend.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticationResponse>();
        CreateMap<User, UserResource>();
    }
}