using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Carts;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {        
        CreateMap<UpdateCartRequest, UpdateCartCommand>();
        CreateMap<Application.Carts.UpdateCart.UpdateCartResponse, Features.Carts.UpdateCart.UpdateCartResponse>();
    }
}