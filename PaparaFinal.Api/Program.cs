using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.BusinessLayer.Concrete;
using PaparaFinal.BusinessLayer.Mapper;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Concrete;
using PaparaFinal.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStringSql = builder.Configuration.GetConnectionString("MsSqlConnection");
builder.Services.AddDbContext<PaparaDbContext>(options => options.UseSqlServer(connectionStringSql));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new UserMapping());
    cfg.AddProfile(new CouponMapping());
    cfg.AddProfile(new ProductMapping());
    cfg.AddProfile(new OrderDetailMapping());
    cfg.AddProfile(new OrderMapping());
    cfg.AddProfile(new CategoryMapping());
    cfg.AddProfile(new DigitalWalletMapping());
    cfg.AddProfile(new CartMapping());
});
builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDigitalWalletService, DigitalWalletService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<PaparaDbContext>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Secret"])),
        ValidAudience = jwtSettings["Audience"],
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(2)
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyAdminUsers", 
        policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaparaAPI", Version = "v1.0" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Papara API Management",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();