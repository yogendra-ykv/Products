using Api.Implementation;
using Api.Interfaces;
using Business;
using Business.Interfaces;
using Repository;
using Repository.Interfaces;

namespace WebApi
{
    public class ServicesIocModule
    {
        private IServiceCollection _services;

        public ServicesIocModule(IServiceCollection services)
        {
            _services = services;
            ResolveServiceModules();
        }

        private void ResolveServiceModules()
        {
            _services.AddScoped<IProductService, ProductService>();
        }
    }
}