using EstoqueAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAPI.Utils
{
    public static class InicializadorDb
    {
        public static void ConfigurarBanco(IServiceCollection services)
        {
            var databasePath = Path.Combine(Directory.GetCurrentDirectory(), "Database");

            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }

            var connectionString = $"Data Source={Path.Combine(databasePath, "EstoqueDb.db")}";

            services.AddDbContext<EstoqueDbContext>(
                options => options.UseSqlite("Data Source=Database/EstoqueDb.db")
            );
        }
    }
}