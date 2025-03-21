using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Response model for UpdateProduct operation
/// </summary>
public class UpdateProductResponse
{
    /// <summary>
    /// Gets or sets the title of the product to be update.
    /// </summary>
    public string Title { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the price of the product to be update.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product to be update.
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the category of the product to be update.
    /// </summary>
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the image URL of the product to be update.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rating of the product to be update.
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0,0);
}