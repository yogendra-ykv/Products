using AutoMapper;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
new ServicesIocModule(builder.Services);
new BusinessIocModule(builder.Services);
new RepositoryIocModule(builder.Services);
var mappingConfig =
    new MapperConfiguration(mc => { mc.AddProfile(new ServiceMapperSetup()); });
mappingConfig.AssertConfigurationIsValid();
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();