using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Resources;

namespace AyniWebBackend.Ayni.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {




        CreateMap<Profit, ProfitResource>();


        CreateMap<Product, ProductResource>();
        CreateMap<Order, OrderResource>();

        CreateMap<Crop, CropResource>();
        CreateMap<Cost, CostResource>();


    }
}