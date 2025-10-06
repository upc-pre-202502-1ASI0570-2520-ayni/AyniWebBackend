using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Persistence.Repositories;
using AyniWebBackend.Ayni.Services;
using AyniWebBackend.Security.Authorization.Handlers.Implementation;
using AyniWebBackend.Security.Authorization.Handlers.Interfaces;
using AyniWebBackend.Security.Authorization.Middleware;
using AyniWebBackend.Security.Authorization.Settings;
using AyniWebBackend.Security.Domain.Repositories;
using AyniWebBackend.Security.Domain.Services;
using AyniWebBackend.Security.Persistence.Repositories;
using AyniWebBackend.Security.Services;
using AyniWebBackend.Shared.Persistence.Contexts;
using AyniWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var misReglasCros = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: misReglasCros,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
    //aqui va la documentación, si pide en el examen se  cambia aqui
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Ayni API",
        Description = "Ayni Crop Management Platform API",
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            Array.Empty<string>()
        }
    });
});


// Add Database Connection
var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//AppSettings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


// Dependency Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<ICostRepository, CostRepository>();
builder.Services.AddScoped<ICostService, CostService>();
builder.Services.AddScoped<IProfitService, ProfitService>();
builder.Services.AddScoped<IProfitRepository, ProfitRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtHandler, JwtHandler>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(AyniWebBackend.Ayni.Mapping.ModelToResourceProfile), 
    typeof(AyniWebBackend.Ayni.Mapping.ResourceToModelProfile),
    typeof(AyniWebBackend.Security.Mapping.ModelToResourceProfile),
    typeof(AyniWebBackend.Security.Mapping.ResourceToModelProfile));


var app = builder.Build();



// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(misReglasCros);
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();