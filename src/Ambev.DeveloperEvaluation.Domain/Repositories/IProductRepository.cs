using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Interface de reposit�rio para opera��es da entidade Product
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Cria um novo produto no reposit�rio
    /// </summary>
    /// <param name="product">O produto a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto criado</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera um produto pelo seu identificador �nico
    /// </summary>
    /// <param name="id">O identificador �nico do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto, se encontrado, ou null caso contr�rio</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera um produto pelo seu t�tulo
    /// </summary>
    /// <param name="title">O t�tulo do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto, se encontrado, ou null caso contr�rio</returns>
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera todos os produtos do reposit�rio
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma cole��o de todos os produtos</returns>
    Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza um produto existente no reposit�rio
    /// </summary>
    /// <param name="product">O produto a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto atualizado</returns>
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exclui um produto do reposit�rio
    /// </summary>
    /// <param name="id">O identificador �nico do produto a ser exclu�do</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o produto foi exclu�do, false caso n�o encontrado</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera uma lista distinta de categorias de produtos do reposit�rio
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma cole��o de categorias �nicas de produtos</returns>
    Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera uma lista de produtos por categoria
    /// </summary>
    /// <param name="category">A categoria dos produtos a serem recuperados</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma cole��o de produtos pertencentes � categoria especificada</returns>
    Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int size, string order, CancellationToken cancellationToken = default);

    Task<int> CountByCategoryAsync(string category, CancellationToken cancellationToken = default);
}