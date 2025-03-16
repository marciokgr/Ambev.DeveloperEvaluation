using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

public class ListProductsByCategoryRequest : PaginatedRequest
{
    /// <summary>
    /// O identificador da categoria dos produtos a serem recuperados
    /// </summary>
    public string Category { get; set; }
}