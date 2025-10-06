using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Resources;

namespace AyniWebBackend.Ayni.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {


 


        CreateMap<SaveProfitResource, Profit>();


        CreateMap<SaveProductResource, Product>();
        CreateMap<SaveOrderResource, Order>();

        CreateMap<SaveCropResource, Crop>();
        CreateMap<SaveCostResource, Cost>();


    }
}