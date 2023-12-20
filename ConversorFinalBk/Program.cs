using ConversorFinal_BE.Data;
using ConversorFinalBk.Data.Interfaces;
using ConversorFinalBk.Repository;
using ConversorFinalBk.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ConversorFinalBk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("ConversorFinalBkApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Acá pegar el token generado al loguearse."
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ConversorFinalBkApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                            }, new List<string>() }
                });
            });
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<CurrencyService>();
            builder.Services.AddScoped<SessionService>();
            builder.Services.AddScoped<ConversionService>();
            builder.Services.AddScoped<SubscriptionService>();
            builder.Services.AddScoped<HistoryService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GeneralRepository<>));
            builder.Services.AddDbContext<ConversorContext>(dbContextOptions => 
            dbContextOptions.UseSqlite(
            builder.Configuration["ConnectionStrings:ConversorDBConnectionString"]));
            builder.Services
            .AddHttpContextAccessor()
            .AddAuthorization()
            .AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
            options.TokenValidationParameters = new TokenValidationParameters
            {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}