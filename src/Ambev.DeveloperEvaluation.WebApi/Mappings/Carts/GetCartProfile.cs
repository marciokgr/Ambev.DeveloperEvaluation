using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Carts;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<Guid, GetCartCommand>()
            .ConstructUsing(id => new GetCartCommand(id));
        
        CreateMap<GetCartResult, GetCartResponse>();
    }
}