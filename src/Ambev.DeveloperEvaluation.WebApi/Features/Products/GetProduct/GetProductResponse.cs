using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    /// <summary>
    /// O identificador único do produto a ser recuperado
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Obtém ou define o nome do produto a ser recuperado
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Obtém ou define o preço do produto a ser recuperado
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Obtém ou define a descrição do produto a ser recuperado
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Obtém ou define a categoria do produto a ser recuperado
    /// </summary>
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Obtém ou define a URL da imagem do produto a ser recuperado
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Obtém ou define a avaliação do produto a ser recuperado
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0, 0);
}