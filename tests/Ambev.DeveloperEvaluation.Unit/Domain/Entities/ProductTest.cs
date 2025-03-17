using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Cont�m testes unit�rios para a classe de entidade Product.
/// Os testes cobrem cen�rios de valida��o e l�gica de neg�cios.
/// </summary>
public class ProductTest
{
    /// <summary>
    /// Testa se a valida��o � aprovada quando todas as propriedades do produto s�o v�lidas.
    /// </summary>
    [Fact(DisplayName = "A valida��o deve passar para dados de produto v�lidos")]
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
    /// Testa se a valida��o falha quando as propriedades do produto s�o inv�lidas.
    /// </summary>
    [Fact(DisplayName = "A valida��o deve falhar para dados de produto inv�lidos")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var product = new Product
        {
            Name = "", // Inv�lido: vazio
            Description = "", // Inv�lido: vazio
            Price = ProductTestData.GenerateInvalidProductPrice(), // Inv�lido: pre�o negativo
            Rating = ProductTestData.GenerateInvalidProductRating(), // Inv�lido: avalia��o fora do intervalo
            Category = ProductTestData.GenerateInvalidProductCategory(), // Inv�lido: categoria n�o atende aos crit�rios
            Image = ProductTestData.GenerateInvalidProductImage() // Inv�lido: imagem n�o atende aos crit�rios
        };

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}