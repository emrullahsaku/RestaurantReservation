using Is_Sistem.API;
using Is_Sistem.DataAccess.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;

namespace Is_Sistem.Api.IntegrationTests.Common;

public static class FactoryExtension
{
    public static async Task<HttpClient> CreateDefaultClientAsync(this ApiApplicationFactory<Program> factory)
    {
        var client = factory.CreateClient();
        
        var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        return client;
    }
    
    public static T GetRequiredService<T>(this ApiApplicationFactory<Program> factory) where T : notnull
    {
        var scope = factory.Services.CreateScope();
        
        return (T)scope.ServiceProvider.GetRequiredService(typeof(T));
    }
}
