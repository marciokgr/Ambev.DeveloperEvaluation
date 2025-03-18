using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementação do repositório para operações da entidade Product
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ProductRepository"/>.
    /// </summary>
    /// <param name="context">O contexto do banco de dados</param>
    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cria um novo produto no repositório
    /// </summary>
    /// <param name="product">O produto a ser criado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto criado</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Set<Product>().AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Recupera um produto pelo seu identificador único
    /// </summary>
    /// <param name="id">O identificador único do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto, se encontrado, ou null caso contrário</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>().FindAsync(new object[] { id }, cancellationToken);
    }

    /// <summary>
    /// Recupera um produto pelo título
    /// </summary>
    /// <param name="name">O nome do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto, se encontrado, ou null caso contrário</returns>
    public async Task<Product?> GetByTitleAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>().FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
    }

    /// <summary>
    /// Recupera todos os produtos do repositório
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de todos os produtos</returns>
    public async Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
    {
        var query = _context.Set<Product>().AsQueryable();

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>().CountAsync(cancellationToken);
    }

    /// <summary>
    /// Atualiza um produto existente no repositório
    /// </summary>
    /// <param name="product">O produto a ser atualizado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>O produto atualizado</returns>
    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Set<Product>().Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Exclui um produto do repositório
    /// </summary>
    /// <param name="id">O identificador único do produto a ser excluído</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>True se o produto foi excluído, false caso não encontrado</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Set<Product>().FindAsync(new object[] { id }, cancellationToken);
        if (product == null)
            return false;

        _context.Set<Product>().Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Recupera uma lista distinta de categorias de produtos do repositório
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de categorias únicas de produtos</returns>
    public async Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>().Select(p => p.Category).Distinct().ToListAsync();
    }

    /// <summary>
    /// Recupera uma lista de produtos por categoria
    /// </summary>
    /// <param name="category">A categoria dos produtos a serem recuperados</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma coleção de produtos pertencentes à categoria especificada</returns>
    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int size, string order,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Set<Product>().Where(p => p.Category == category);

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
    }

    public async Task<int> CountByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>().CountAsync(p => p.Category == category, cancellationToken);
    }
}