using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Esta classe representa um produto.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Precço do produto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Descricao do produto.
        /// </summary>
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Categoria do produto.
        /// </summary>
        public string Category { get; set; } = String.Empty;

        /// <summary>
        /// Imagem do produto.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Classificação do produto.
        /// </summary>
        public Rating Rating { get; set; } = new Rating(0, 0);

        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
