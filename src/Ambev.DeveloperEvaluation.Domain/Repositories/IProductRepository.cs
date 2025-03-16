using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Interface de repositório para operações da entidade Product
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Cria um novo produto no repositório
    /// </summary>
    /// <param name="product">O produto a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto criado</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera um produto pelo seu identificador único
    /// </summary>
    /// <param name="id">O identificador único do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto, se encontrado, ou null caso contrário</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera um produto pelo seu título
    /// </summary>
    /// <param name="title">O título do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto, se encontrado, ou null caso contrário</returns>
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera todos os produtos do repositório
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de todos os produtos</returns>
    Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza um produto existente no repositório
    /// </summary>
    /// <param name="product">O produto a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto atualizado</returns>
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exclui um produto do repositório
    /// </summary>
    /// <param name="id">O identificador único do produto a ser excluído</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o produto foi excluído, false caso não encontrado</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera uma lista distinta de categorias de produtos do repositório
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de categorias únicas de produtos</returns>
    Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera uma lista de produtos por categoria
    /// </summary>
    /// <param name="category">A categoria dos produtos a serem recuperados</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de produtos pertencentes à categoria especificada</returns>
    Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int size, string order, CancellationToken cancellationToken = default);

    Task<int> CountByCategoryAsync(string category, CancellationToken cancellationToken = default);
}