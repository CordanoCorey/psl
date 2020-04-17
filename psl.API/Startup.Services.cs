using Microsoft.Extensions.DependencyInjection;
using psl.API.Infrastructure.Lookup;

namespace psl.API
{
    public partial class Startup
    {
        public static void ConfigureScopedServices(IServiceCollection services)
        {
            //Shared
            services.AddScoped<ILookupRepository, LookupRepository>();
        }
    }
}
