using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa um item em uma transação de carrinho.
    /// </summary>
    public class CartItem : BaseEntity
    {
        /// <summary>
        /// Obtém ou define o identificador único do produto.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do produto.
        /// </summary>
        [NotMapped]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a quantidade do produto que está sendo vendido.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Obtém ou define o preço unitário do produto.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Obtém ou define o desconto aplicado ao item do carrinho.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Obtém ou define o preço total do item do carrinho após aplicar o desconto.
        /// </summary>
        public decimal TotalPrice { get; set; }

        // Chave estrangeira para o carrinho
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        /// <summary>
        /// Calcula o preço total do item do carrinho com base na quantidade e no preço unitário,
        /// e aplica o desconto apropriado com base na quantidade.
        /// </summary>
        /// <exception cref="DomainException">
        /// Lançada quando a quantidade excede 20, pois não é permitido vender mais de 20 itens idênticos.
        /// </exception>
        public void CalculateTotalPrice()
        {
            if (Quantity is >= 4 and < 10)
            {
                Discount = 0.10m;
            }
            else if (Quantity is >= 10 and <= 20)
            {
                Discount = 0.20m;
            }
            else if (Quantity > 20)
            {
                throw new DomainException("Cannot sell more than 20 identical items.");
            }
            else
            {
                Discount = 0.0m;
            }

            TotalPrice = Quantity * UnitPrice * (1 - Discount);
        }
    }
}
