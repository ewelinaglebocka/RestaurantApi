using NLog.Web;
using RestaurantApi;
using RestaurantApi.Entities;
using RestaurantApi.Middleware;
using RestaurantApi.Services;
using RestaurantAPI;
using static RestaurantApi.Services.AccountService;

var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RestaurantDbContext>();
builder.Services.AddScoped<RestaurantSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ErrorHandingMiddleware>();
builder.Services.AddScoped<RequestTimeMidleware>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDishService, DishService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();
seeder.Seed();

app.UseMiddleware<ErrorHandingMiddleware>();
app.UseMiddleware<RequestTimeMidleware>();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Api");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
