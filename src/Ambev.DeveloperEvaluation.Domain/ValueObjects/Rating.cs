namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class Rating
    {
        /// <summary>
        /// Obtém a classificação (nota) do produto.
        /// </summary>
        public decimal Rate { get; }

        /// <summary>
        /// Obtém a quantidade de avaliações para o produto.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Rating"/>.
        /// </summary>
        /// <param name="rate">A classificação (nota) do produto.</param>
        /// <param name="count">A quantidade de avaliações para o produto.</param>
        public Rating(decimal rate, int count)
        {
            Rate = rate;
            Count = count;
        }

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com o objeto atual.</param>
        /// <returns>true se o objeto especificado for igual ao objeto atual; caso contrário, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Rating rating)
            {
                return Rate == rating.Rate && Count == rating.Count;
            }
            return false;
        }

        /// <summary>
        /// Serve como a função hash padrão.
        /// </summary>
        /// <returns>Um código hash para o objeto atual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Rate, Count);
        }
    }
}
