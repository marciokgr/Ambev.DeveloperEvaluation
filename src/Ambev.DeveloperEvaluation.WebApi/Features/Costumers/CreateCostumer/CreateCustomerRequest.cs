using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Costumers.CreateCostumer
{
    public sealed record CreateCustomerRequest(CreateUserRequest UserRequest, string Name, string ExternalId);
}
