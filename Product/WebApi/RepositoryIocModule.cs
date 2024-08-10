using Repository.Interfaces;
using Repository;

namespace WebApi
{
    public class RepositoryIocModule
    {
        private readonly IServiceCollection _services;

        public RepositoryIocModule(IServiceCollection services)
        {
            _services = services;
            ResolveRepositoryModules();
        }

        private void ResolveRepositoryModules()
        {
            _services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}