using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Fornece m�todos para gerar dados de teste usando a biblioteca Bogus.
/// Esta classe centraliza toda a gera��o de dados de teste para garantir consist�ncia
/// entre os casos de teste e fornecer cen�rios com dados v�lidos e inv�lidos.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configura o Faker para gerar entidades de Produto v�lidas.
    /// Os produtos gerados ter�o:
    /// - Nome v�lido
    /// - Descri��o v�lida
    /// - Pre�o v�lido
    /// - Avalia��o v�lida
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
        .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
        .RuleFor(p => p.Image, f => f.Image.PicsumUrl())
        .RuleFor(p => p.Rating, f => new Rating(f.Random.Decimal(1, 5), f.Random.Int(1, 100)));

    /// <summary>
    /// Gera uma entidade de Produto v�lida com dados aleat�rios.
    /// O produto gerado ter� todas as propriedades preenchidas com valores v�lidos
    /// que atendem aos requisitos de valida��o do sistema.
    /// </summary>
    /// <returns>Uma entidade de Produto v�lida com dados gerados aleatoriamente.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Gera um nome de produto v�lido.
    /// O nome gerado ser�:
    /// - Um nome de produto realista
    /// </summary>
    /// <returns>Um nome de produto v�lido.</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Gera uma descri��o de produto v�lida.
    /// A descri��o gerada ser�:
    /// - Uma descri��o de produto realista
    /// </summary>
    /// <returns>Uma descri��o de produto v�lida.</returns>
    public static string GenerateValidProductDescription()
    {
        return new Faker().Commerce.ProductDescription();
    }

    /// <summary>
    /// Gera um pre�o de produto v�lido.
    /// O pre�o gerado ser�:
    /// - Um valor decimal entre 1 e 1000
    /// </summary>
    /// <returns>Um pre�o de produto v�lido.</returns>
    public static decimal GenerateValidProductPrice()
    {
        return new Faker().Random.Decimal(1, 1000);
    }

    /// <summary>
    /// Gera uma categoria de produto v�lida.
    /// A categoria gerada ser�:
    /// - Uma categoria de produto realista
    /// </summary>
    /// <returns>Uma categoria de produto v�lida.</returns>
    public static string GenerateValidProductCategory()
    {
        return new Faker().Commerce.Categories(1)[0];
    }

    /// <summary>
    /// Gera uma URL de imagem de produto v�lida.
    /// A URL gerada ser�:
    /// - Uma URL realista para imagem de produto
    /// </summary>
    /// <returns>Uma URL de imagem de produto v�lida.</returns>
    public static string GenerateValidProductImage()
    {
        return new Faker().Image.PicsumUrl();
    }

    /// <summary>
    /// Gera uma avalia��o de produto v�lida.
    /// A avalia��o gerada ter�:
    /// - Uma nota entre 1 e 5
    /// - Um n�mero de avalia��es entre 1 e 100
    /// </summary>
    /// <returns>Uma avalia��o de produto v�lida.</returns>
    public static Rating GenerateValidProductRating()
    {
        var faker = new Faker();
        return new Rating(faker.Random.Decimal(1, 5), faker.Random.Int(1, 100));
    }

    /// <summary>
    /// Gera um pre�o de produto inv�lido para testar cen�rios negativos.
    /// O pre�o gerado ser�:
    /// - Um valor decimal negativo
    /// </summary>
    /// <returns>Um pre�o de produto inv�lido.</returns>
    public static decimal GenerateInvalidProductPrice()
    {
        return new Faker().Random.Decimal(-1000, -1);
    }

    /// <summary>
    /// Gera uma avalia��o de produto inv�lida para testar cen�rios negativos.
    /// A avalia��o gerada ter�:
    /// - Uma nota fora do intervalo de 1 a 5
    /// </summary>
    /// <returns>Uma avalia��o de produto inv�lida.</returns>
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