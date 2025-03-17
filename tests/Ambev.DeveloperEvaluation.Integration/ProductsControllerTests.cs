using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using Ambev.DeveloperEvaluation.Integration.Helpers;

namespace Ambev.DeveloperEvaluation.Integration
{
    public class ProductsControllerTests
    {
        private readonly HttpClient _client;

        public ProductsControllerTests()
        {
            _client = CustomHttpClientFactory.Create();
        }

        /*[Fact(DisplayName = "GET /api/products retorna status 200 e lista de produtos")]
        public async Task GetProducts_ShouldReturnOkWithProducts()
        {
            // Act: Faz chamada GET no endpoint
            var response = await _client.GetAsync("/api/products");

            // Assert: Verifica o status 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Verifica se o JSON retornado contém a lista de produtos
            var products = await response.Content.ReadFromJsonAsync<PaginatedResponse<ListProductsResponse>>();
            Assert.NotNull(products); // Garante que os produtos não sejam nulos
        }

        [Fact(DisplayName = "POST /api/products cria um novo produto e retorna status 201")]
        public async Task CreateProduct_ShouldReturnCreated()
        {
            // Arrange: Cria um novo produto
            var newProduct = new
            {
                Name = "Produto Teste",
                Price = 99.99m,
                Description = "Descrição do Produto Teste",
                Category = "Categoria Teste",
                Image = "https://fakeimage.com/imagem.jpg",
                Rating = new { Value = 4.5m, Count = 10 }
            };

            // Act: Faz chamada POST no endpoint
            var response = await _client.PostAsJsonAsync("/api/products", newProduct);

            // Assert: Verifica se o status retornado é 201 Created
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Verifica se os dados do produto foram retornados corretamente
            var createdProduct = await response.Content.ReadFromJsonAsync<ApiResponseWithData<CreateProductResponse>>();
            Assert.NotNull(createdProduct); // Verifica que o produto criado não é nulo
            Assert.Equal(newProduct.Name, createdProduct!.Data.Name); // Compara os nomes
        }

        [Fact(DisplayName = "GET /api/products/{id} retorna 404 para produto inexistente")]
        public async Task GetProductById_NonExistent_ShouldReturnNotFound()
        {
            // Arrange: Gera um ID aleatório para produto inexistente
            var nonExistentId = Guid.NewGuid();

            // Act: Faz chamada GET no endpoint
            var response = await _client.GetAsync($"/api/products/{nonExistentId}");

            // Assert: Verifica se o status retornado é 404 Not Found
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }*/
    }
}