using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using UpdateProductResponse = Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct.UpdateProductResponse;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<Application.Products.UpdateProduct.UpdateProductResponse, UpdateProductResponse>();
    }
}