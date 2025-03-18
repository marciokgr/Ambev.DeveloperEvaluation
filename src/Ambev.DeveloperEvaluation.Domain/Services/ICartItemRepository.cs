using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

/// <summary>
/// Interface de reposit�rio para opera��es da entidade CartItem
/// </summary>
public interface ICartItemRepository
{
    /// <summary>
    /// Cria um novo item de carrinho no reposit�rio
    /// </summary>
    /// <param name="cartItem">O item de carrinho a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O item de carrinho criado</returns>
    Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera um item de carrinho pelo seu identificador �nico
    /// </summary>
    /// <param name="id">O identificador �nico do item de carrinho</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O item de carrinho, se encontrado, ou null caso contr�rio</returns>
    Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<CartItem>> GetByCartIdAsync(Guid CartId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recupera todos os itens de carrinho do reposit�rio
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma cole��o de todos os itens de carrinho</returns>
    Task<IEnumerable<CartItem>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza um item de carrinho existente no reposit�rio
    /// </summary>
    /// <param name="cartItem">O item de carrinho a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O item de carrinho atualizado</returns>
    Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exclui um item de carrinho do reposit�rio
    /// </summary>
    /// <param name="id">O identificador �nico do item de carrinho a ser exclu�do</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o item de carrinho foi exclu�do, false caso n�o encontrado</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> DeleteByCartIdAsync(Guid CartId, CancellationToken cancellationToken = default);
}