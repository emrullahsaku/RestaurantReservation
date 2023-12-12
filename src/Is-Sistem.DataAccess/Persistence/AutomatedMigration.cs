using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Is_Sistem.DataAccess.Repositories;

namespace Is_Sistem.DataAccess.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DatabaseContext>();

        if (context.Database.IsSqlServer()) await context.Database.MigrateAsync();

        var tableRepository = services.GetRequiredService<ITableRepository>();

        await DatabaseContextSeed.SeedReservationTableAsync(context, tableRepository);
    }
}
