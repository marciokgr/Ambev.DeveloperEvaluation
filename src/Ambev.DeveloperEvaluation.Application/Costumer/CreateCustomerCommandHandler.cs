using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Costumer
{
    public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IMediator mediator)
     : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
    {
        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var createdUser = await mediator.Send(command.UserCommand, cancellationToken);

            var customer = mapper.Map<Customer>(command);

            customer.SetUserId(createdUser.Id);

            var createdCustomer = await customerRepository.CreateAsync(customer, cancellationToken);
            var result = mapper.Map<CreateCustomerResult>(createdCustomer);
            return result;
        }
    }
}
