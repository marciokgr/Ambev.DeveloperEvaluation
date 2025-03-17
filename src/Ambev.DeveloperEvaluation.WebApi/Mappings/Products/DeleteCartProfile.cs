using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Products;
public class DeleteCartProfile : Profile
{
    public DeleteCartProfile()
    {
        CreateMap<DeleteCartRequest, DeleteCartCommand>();
    }
}