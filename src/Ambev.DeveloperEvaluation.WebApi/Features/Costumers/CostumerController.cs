using Ambev.DeveloperEvaluation.Application.Costumer;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Costumers.CreateCostumer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(IMediator mediator, IMapper mapper) : BaseController
{
    /// <summary>
    ///     Cria um novo cliente
    /// </summary>
    /// <param name="request">A solicitação para criação do cliente</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Os detalhes do cliente criado</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = mapper.Map<CreateCustomerCommand>(request);
        var response = await mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCustomerResponse>
        {
            Success = true,
            Message = "Cliente criado com sucesso",
            Data = mapper.Map<CreateCustomerResponse>(response)
        });
    }
}