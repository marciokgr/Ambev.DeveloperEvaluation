using Xunit;
using FluentValidation.TestHelper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Testes para validar o comportamento do ProductValidator.
/// </summary>
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        // Instancia o validador do Produto
        _validator = new ProductValidator();
    }

    [Fact(DisplayName = "Produto com dados inválidos deve falhar na validação")]
    public void Given_InvalidProduct_When_Validated_Then_ShouldHaveErrors()
    {
        
    }
}