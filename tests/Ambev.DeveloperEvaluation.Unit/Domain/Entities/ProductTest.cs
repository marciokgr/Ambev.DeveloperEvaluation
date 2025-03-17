using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contém testes unitários para a classe de entidade Product.
/// Os testes cobrem cenários de validação e lógica de negócios.
/// </summary>
public class ProductTest
{
    /// <summary>
    /// Testa se a validação é aprovada quando todas as propriedades do produto são válidas.
    /// </summary>
    [Fact(DisplayName = "A validação deve passar para dados de produto válidos")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = product.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Testa se a validação falha quando as propriedades do produto são inválidas.
    /// </summary>
    [Fact(DisplayName = "A validação deve falhar para dados de produto inválidos")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var product = new Product
        {
            Name = "", // Inválido: vazio
            Description = "", // Inválido: vazio
            Price = ProductTestData.GenerateInvalidProductPrice(), // Inválido: preço negativo
            Rating = ProductTestData.GenerateInvalidProductRating(), // Inválido: avaliação fora do intervalo
            Category = ProductTestData.GenerateInvalidProductCategory(), // Inválido: categoria não atende aos critérios
            Image = ProductTestData.GenerateInvalidProductImage() // Inválido: imagem não atende aos critérios
        };

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}