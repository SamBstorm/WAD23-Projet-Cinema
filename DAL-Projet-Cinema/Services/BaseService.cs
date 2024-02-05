using Microsoft.Extensions.Configuration;

namespace DAL_Projet_Cinema.Services
{
    public abstract class BaseService
    {
        protected readonly string connectionString;

        public BaseService(IConfiguration configuration, string dbname)
        {
            connectionString = configuration.GetConnectionString(dbname);
        }
    }
}
