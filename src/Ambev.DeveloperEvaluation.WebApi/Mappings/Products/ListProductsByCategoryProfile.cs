using Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class ListProductsByCategoryProfile : Profile
{
    public ListProductsByCategoryProfile()
    {
        CreateMap<ListProductsByCategoryProductDto, ListProductsByCategoryResponse>();
    }
}