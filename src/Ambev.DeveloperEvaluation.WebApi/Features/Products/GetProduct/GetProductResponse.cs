using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    /// <summary>
    /// O identificador �nico do produto a ser recuperado
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Obt�m ou define o nome do produto a ser recuperado
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Obt�m ou define o pre�o do produto a ser recuperado
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Obt�m ou define a descri��o do produto a ser recuperado
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Obt�m ou define a categoria do produto a ser recuperado
    /// </summary>
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Obt�m ou define a URL da imagem do produto a ser recuperado
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Obt�m ou define a avalia��o do produto a ser recuperado
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0, 0);
}