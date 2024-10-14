using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OData.UriParser;
using Microsoft.AspNetCore.OData;
using BACK.CORE.Interfaces;
using BACK.CORE.Services;
using BACK.UI.Controllers.Helpers;
using BACK.IL.Repository.EF;
using BACK.IL.Repository;

namespace BACK.UI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static readonly string[] value = ["Bearer"];

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });

            // Add SignalR
            services.AddSignalR();

            services.AddDbContext<Context>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // Automapper
            var mapperAssembly = Assembly.Load(new AssemblyName("BACK.IL.Mapper.AM"));
            services.AddAutoMapper(mapperAssembly);

            // OData
            services.TryAddSingleton<ODataUriResolver>(_ => new ODataUriResolver() { EnableCaseInsensitive = true });

            // Swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ejemplo", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, value }
                };
                c.AddSecurityRequirement(securityRequirement);
            });

            // WORKAROUND FOR MAKING ODATA WORK WITH SWAGGER
            // https://github.com/OData/WebApi/issues/1177#issuecomment-358659774
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            // Repository Pattern
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();

            // Clean Architecture
            services.AddScoped<IServiceManager, ServiceManager>();

            // Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = JWTHelper.GetValidationParameters(Configuration);
                });

            /*services.AddAuthorization(options => // Security Policy to check certain claims in JWT
            {
                options.AddPolicy("Administrador", policy => policy.RequireClaim("Ejemplo", "True"));
            });*/

            services.AddControllers()
                .AddOData()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.AddControllers();

            // Add logging
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Middleware para configurar la redirección HTTPS
            app.UseHttpsRedirection();

            // Middleware para configurar el enrutamiento de la solicitud
            app.UseRouting();

            // Middleware para configurar la política de CORS
            app.UseCors();

            // Middleware para autenticación
            app.UseAuthentication();

            // Middleware para autorización
            app.UseAuthorization();

            // Middleware para configurar los endpoints de la aplicación
            app.UseEndpoints(endpoints =>
            {
                // Mapear los controladores de API
                endpoints.MapControllers();
            });

            // Middleware para habilitar Swagger
            // Habilitar el middleware para servir Swagger JSON
            app.UseSwagger();
            // Especificar el endpoint de Swagger JSON
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ejemplo Doc");
            });

            // Middleware de página de error de desarrollador
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}