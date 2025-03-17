using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Integration.Helpers;

// <summary>
/// Fábrica personalizada para hospedar e configurar a aplicação durante os testes de integração.
/// </summary>
/// <typeparam name="TProgram">A classe principal do projeto, geralmente "Program".</typeparam>
public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    /// <summary>
    /// Configura o host da aplicação para o ambiente de teste.
    /// </summary>
    /// <param name="builder">Construtor do host web.</param>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remover configuração do banco de dados real
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<DbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }               

            // Garantir que o banco em memória seja inicializado com dados de teste
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DbContext>();

                db.Database.EnsureCreated();
            }
        });
    }       
}
