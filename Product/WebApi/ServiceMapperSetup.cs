using Api.Models;
using AutoMapper;

namespace WebApi
{
    public class ServiceMapperSetup : Profile
    {
        public ServiceMapperSetup()
        {
            AllowNullCollections = true;
            SetUp();
        }

        public void SetUp()
        {
            CreateMap<Business.Models.ProductModel, ProductModel>();
            CreateMap<ProductModel, Business.Models.ProductModel>();
        }
    }
}