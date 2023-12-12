using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Is_Sistem.API;

public static class ApiDependencyInjection
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
    }
}
