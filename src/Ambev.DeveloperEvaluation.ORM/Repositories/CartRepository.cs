using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementa��o do reposit�rio para opera��es na entidade Cart
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DbContext _context;

    /// <summary>
    /// Inicializa uma nova inst�ncia da classe <see cref="CartRepository"/>.
    /// </summary>
    /// <param name="context">O contexto do banco de dados</param>
    public CartRepository(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cria um novo carrinho no reposit�rio
    /// </summary>
    /// <param name="cart">O carrinho a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O carrinho criado</returns>
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Set<Cart>().AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Recupera um carrinho pelo seu identificador �nico
    /// </summary>
    /// <param name="id">O identificador �nico do carrinho</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O carrinho, se encontrado, ou null caso contr�rio</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Cart>()
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<Cart?> GetByUserIdAsync(Guid UserId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Cart>()
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.UserId == UserId && !s.IsCancelled, cancellationToken);
    }

    /// <summary>
    /// Recupera todos os carrinhos do reposit�rio
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma cole��o de todos os carrinhos</returns>
    public async Task<IEnumerable<Cart>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
    {
        var query = _context.Set<Cart>().AsQueryable();

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Cart>().CountAsync(cancellationToken);
    }

    /// <summary>
    /// Atualiza um carrinho existente no reposit�rio
    /// </summary>
    /// <param name="cart">O carrinho a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O carrinho atualizado</returns>
    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Set<Cart>().Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Exclui um carrinho do reposit�rio
    /// </summary>
    /// <param name="id">O identificador �nico do carrinho a ser exclu�do</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o carrinho foi exclu�do, false se n�o encontrado</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Set<Cart>().FindAsync(new object[] { id }, cancellationToken);
        if (cart == null)
            return false;

        _context.Set<Cart>().Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}