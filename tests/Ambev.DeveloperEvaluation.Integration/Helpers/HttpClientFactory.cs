
namespace Ambev.DeveloperEvaluation.Integration.Helpers;

public static class CustomHttpClientFactory
{
    /// <summary>
    /// Cria uma instância personalizada do HttpClient direcionada a localhost:5119.
    /// </summary>
    public static HttpClient Create()
    {
        var handler = new HttpClientHandler
        {
            AllowAutoRedirect = false,
            UseCookies = false
        };

        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri("http://localhost:5119") // Define a URL base
        };

        client.DefaultRequestHeaders.Add("Accept", "application/json");

        return client;
    }
}

