using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace demoCRUD.Models
{
    public class AppContext :DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
