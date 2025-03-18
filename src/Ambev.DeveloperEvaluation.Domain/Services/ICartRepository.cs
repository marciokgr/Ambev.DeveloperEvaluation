using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

/// <summary>
/// Interface de repositório para operações da entidade Cart
/// </summary>
public interface ICartRepository
{
    /// <summary>
    /// Cria um novo carrinho no repositório
    /// </summary>
    /// <param name="cart">O carrinho a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O carrinho criado</returns>
    Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera um carrinho pelo seu identificador único
    /// </summary>
    /// <param name="id">O identificador único do carrinho</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O carrinho, se encontrado, ou null caso contrário</returns>
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Cart?> GetByUserIdAsync(Guid UserId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera todos os carrinhos do repositório
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de todos os carrinhos</returns>
    Task<IEnumerable<Cart>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza um carrinho existente no repositório
    /// </summary>
    /// <param name="cart">O carrinho a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O carrinho atualizado</returns>
    Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exclui um carrinho do repositório
    /// </summary>
    /// <param name="id">O identificador único do carrinho a ser excluído</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o carrinho foi excluído, false caso não encontrado</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}