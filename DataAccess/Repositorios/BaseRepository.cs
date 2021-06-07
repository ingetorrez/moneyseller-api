using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositorios
{
    public class BaseRepository
    {
        protected readonly IConfiguration Configuration;

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected string ConnectionString
        {
            get { return Configuration.GetConnectionString("Default"); }
        }
    }
}
