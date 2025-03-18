using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementação do repositório para operações na entidade CartItem
/// </summary>
public class CartItemRepository : ICartItemRepository
{
    private readonly DbContext _context;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="CartItemRepository"/>.
    /// </summary>
    /// <param name="context">O contexto do banco de dados</param>
    public CartItemRepository(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cria um novo item de carrinho no repositório
    /// </summary>
    /// <param name="cartItem">O item de carrinho a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O item de carrinho criado</returns>
    public async Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
    {
        await _context.Set<CartItem>().AddAsync(cartItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cartItem;
    }

    /// <summary>
    /// Recupera um item de carrinho pelo seu identificador único
    /// </summary>
    /// <param name="id">O identificador único do item de carrinho</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O item de carrinho, se encontrado, ou null caso contrário</returns>
    public async Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<CartItem>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<CartItem>> GetByCartIdAsync(Guid CartId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<CartItem>().Where(c => c.CartId == CartId).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Recupera todos os itens de carrinho do repositório
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de todos os itens de carrinho</returns>
    public async Task<IEnumerable<CartItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<CartItem>().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Atualiza um item de carrinho existente no repositório
    /// </summary>
    /// <param name="cartItem">O item de carrinho a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O item de carrinho atualizado</returns>
    public async Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
    {
        _context.Set<CartItem>().Update(cartItem);
        await _context.SaveChangesAsync(cancellationToken);
        return cartItem;
    }

    /// <summary>
    /// Exclui um item de carrinho do repositório
    /// </summary>
    /// <param name="id">O identificador único do item de carrinho a ser excluído</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o item de carrinho foi excluído, false se não encontrado</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cartItem = await _context.Set<CartItem>().FindAsync(new object[] { id }, cancellationToken);
        if (cartItem == null)
            return false;

        _context.Set<CartItem>().Remove(cartItem);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Exclui um item de carrinho pelo id do Carrinho
    /// </summary>
    /// <param name="CartId">O identificador único do carrinho a ser excluído</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o item de carrinho foi excluído, false se não encontrado</returns>
    public async Task<bool> DeleteByCartIdAsync(Guid CartId, CancellationToken cancellationToken = default)
    {
        var cartItems = await GetByCartIdAsync(CartId);
        if (!cartItems.Any())
            return false;

        _context.Set<CartItem>().RemoveRange(cartItems);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}