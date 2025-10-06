using AutoMapper;
using AyniWebBackend.Security.Domain.Models;
using AyniWebBackend.Security.Domain.Services.Communication;

namespace AyniWebBackend.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>().ForAllMembers(options => options.Condition(
            (source, target, property) =>
            {
                if (property == null) return false;
                if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                return true;
            }
        ));

    }
}