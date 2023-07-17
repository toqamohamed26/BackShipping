using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shipping.Data;
using Shipping.Models;
using Shipping.Repository;
using System.Security.Claims;
using System.Text;

namespace Shipping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Database 

            var ConnectionString = builder.Configuration.GetConnectionString("Shipping");
            builder.Services.AddDbContext<ShippingContext>(options =>
            options.UseSqlServer(ConnectionString)
            );
            #endregion

            #region IdentityMangers

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 5;

                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ShippingContext>();
            builder.Services.AddScoped<IRepresentiveRepository, RepresentiveRepository>();
            builder.Services.AddScoped<GovernatesReposaitory>();
            builder.Services.AddScoped<CitiesReposaitory>();
            builder.Services.AddScoped<BranchesRepo>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ISpecialPriceRepository, SpecialPriceRepository>();
            builder.Services.AddScoped<ITraderRepository, TraderRepository>();
            builder.Services.AddScoped<IWeight_Setting, Weight_Setting_Repo>();
            builder.Services.AddScoped<IShipping_Setting, Shipping_Setting_Repo>();
            builder.Services.AddScoped<IVallageSetting, VillageSettingRepo>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICities, CitiesReposaitory>();



            #endregion

            #region Authentication Scheme

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
            .AddJwtBearer("Cool", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
                var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            #endregion


            #region Policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Trader", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Trader")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("Employee", policy => policy
                     .RequireClaim(ClaimTypes.Role, "Employee")
                     .RequireClaim(ClaimTypes.NameIdentifier));
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
