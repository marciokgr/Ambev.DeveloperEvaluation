using Ambev.DeveloperEvaluation.Application.Costumer;
using Ambev.DeveloperEvaluation.WebApi.Features.Costumers.CreateCostumer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Costumers
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>()
                .ForMember(dest => dest.UserCommand, opt => opt.MapFrom(src => src.UserRequest));
            CreateMap<CreateCustomerResult, CreateCustomerResponse>().ReverseMap();
        }
    }
}
