using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Costumer
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ReverseMap();
            CreateMap<Customer, CreateCustomerResult>()
                .ReverseMap();
        }
    }
}
