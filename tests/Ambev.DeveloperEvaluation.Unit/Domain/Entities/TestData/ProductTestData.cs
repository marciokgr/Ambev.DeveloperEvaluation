using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Fornece métodos para gerar dados de teste usando a biblioteca Bogus.
/// Esta classe centraliza toda a geração de dados de teste para garantir consistência
/// entre os casos de teste e fornecer cenários com dados válidos e inválidos.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configura o Faker para gerar entidades de Produto válidas.
    /// Os produtos gerados terão:
    /// - Nome válido
    /// - Descrição válida
    /// - Preço válido
    /// - Avaliação válida
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
        .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
        .RuleFor(p => p.Image, f => f.Image.PicsumUrl())
        .RuleFor(p => p.Rating, f => new Rating(f.Random.Decimal(1, 5), f.Random.Int(1, 100)));

    /// <summary>
    /// Gera uma entidade de Produto válida com dados aleatórios.
    /// O produto gerado terá todas as propriedades preenchidas com valores válidos
    /// que atendem aos requisitos de validação do sistema.
    /// </summary>
    /// <returns>Uma entidade de Produto válida com dados gerados aleatoriamente.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Gera um nome de produto válido.
    /// O nome gerado será:
    /// - Um nome de produto realista
    /// </summary>
    /// <returns>Um nome de produto válido.</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Gera uma descrição de produto válida.
    /// A descrição gerada será:
    /// - Uma descrição de produto realista
    /// </summary>
    /// <returns>Uma descrição de produto válida.</returns>
    public static string GenerateValidProductDescription()
    {
        return new Faker().Commerce.ProductDescription();
    }

    /// <summary>
    /// Gera um preço de produto válido.
    /// O preço gerado será:
    /// - Um valor decimal entre 1 e 1000
    /// </summary>
    /// <returns>Um preço de produto válido.</returns>
    public static decimal GenerateValidProductPrice()
    {
        return new Faker().Random.Decimal(1, 1000);
    }

    /// <summary>
    /// Gera uma categoria de produto válida.
    /// A categoria gerada será:
    /// - Uma categoria de produto realista
    /// </summary>
    /// <returns>Uma categoria de produto válida.</returns>
    public static string GenerateValidProductCategory()
    {
        return new Faker().Commerce.Categories(1)[0];
    }

    /// <summary>
    /// Gera uma URL de imagem de produto válida.
    /// A URL gerada será:
    /// - Uma URL realista para imagem de produto
    /// </summary>
    /// <returns>Uma URL de imagem de produto válida.</returns>
    public static string GenerateValidProductImage()
    {
        return new Faker().Image.PicsumUrl();
    }

    /// <summary>
    /// Gera uma avaliação de produto válida.
    /// A avaliação gerada terá:
    /// - Uma nota entre 1 e 5
    /// - Um número de avaliações entre 1 e 100
    /// </summary>
    /// <returns>Uma avaliação de produto válida.</returns>
    public static Rating GenerateValidProductRating()
    {
        var faker = new Faker();
        return new Rating(faker.Random.Decimal(1, 5), faker.Random.Int(1, 100));
    }

    /// <summary>
    /// Gera um preço de produto inválido para testar cenários negativos.
    /// O preço gerado será:
    /// - Um valor decimal negativo
    /// </summary>
    /// <returns>Um preço de produto inválido.</returns>
    public static decimal GenerateInvalidProductPrice()
    {
        return new Faker().Random.Decimal(-1000, -1);
    }

    /// <summary>
    /// Gera uma avaliação de produto inválida para testar cenários negativos.
    /// A avaliação gerada terá:
    /// - Uma nota fora do intervalo de 1 a 5
    /// </summary>
    /// <returns>Uma avaliação de produto inválida.</returns>
    public static Rating GenerateInvalidProductRating()
    {
        var faker = new Faker();
        return new Rating(faker.Random.Decimal(6, 10), faker.Random.Int(1, 100));
    }

    public static string GenerateInvalidProductCategory()
    {
        return new Faker().Lorem.Word();
    }

    public static string GenerateInvalidProductImage()
    {
        return new Faker().Lorem.Word();
    }
}