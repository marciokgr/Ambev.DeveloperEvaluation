using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequest
{
    /// <summary>
    /// Obtém ou define o nome do produto a ser criado
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Obtém ou define o preço do produto a ser criado
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Obtém ou define a descrição do produto a ser criado
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Obtém ou define a categoria do produto a ser criado
    /// </summary>
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Obtém ou define a URL da imagem do produto a ser criado
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Obtém ou define a avaliação do produto a ser criado
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0, 0);
}