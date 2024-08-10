using Business.Interfaces;
using Business;
using Repository.Interfaces;
using Repository;

namespace WebApi
{
    public class BusinessIocModule
    {
        private readonly IServiceCollection _services;

        public BusinessIocModule(IServiceCollection services)
        {
            _services = services;
            ResolveBusinessModules();
        }

        private void ResolveBusinessModules()
        {
            _services.AddScoped<IProductBusiness, ProductBusiness>();
        }
    }
}