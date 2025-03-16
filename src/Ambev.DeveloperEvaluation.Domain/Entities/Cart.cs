using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa uma transação de carrinho no sistema.
    /// </summary>
    public class Cart : BaseEntity
    {
        /// <summary>
        /// Obtém ou define o número do carrinho.
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a data em que o carrinho foi criado.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Obtém ou define o identificador único do cliente.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        [NotMapped]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o valor total do carrinho.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Obtém ou define o nome da filial.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a lista de itens no carrinho.
        /// </summary>
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        /// <summary>
        /// Obtém ou define um valor indicando se o carrinho foi cancelado.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Adiciona um item ao carrinho.
        /// </summary>
        /// <param name="item">O item a ser adicionado.</param>
        public void AddItem(CartItem item)
        {
            item.CalculateTotalPrice();
            Items.Add(item);
            CalculateTotalAmount();
        }

        /// <summary>
        /// Cancela o carrinho.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
        }

        /// <summary>
        /// Calcula o valor total do carrinho.
        /// </summary>
        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                TotalAmount += item.TotalPrice;
            }
        }
    }
}
