using Meetups.Application;
using Meetups.Application.Common.Mappings;
using Meetups.Application.Interfaces;
using Meetups.Persistence;
using Meetups.WebApi.JwtAuth;
using Meetups.WebApi.Middlewares.ExceptionHandler;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Meetups.WebApi
{
    public class Program
    {
    
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services=builder.Services;


            services.ConfigureJWT();


            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IMeetupsDbContext).Assembly));
            });

            services.AddSingleton<ITokenService,JwtTokenService>();

            services.AddApplication();
            services.AddPersistence(builder.Configuration);
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.RoutePrefix = String.Empty;
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseCustomExceptionHandler();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


using (var scope = builder.Services.BuildServiceProvider().CreateScope()) // invoke method of Db initialization
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<MeetupsDbContext>(); // for accessing dependencies
                    DbInitializer.Initialize(context); // initialize database
                }
                catch (Exception e) { }
            }
            // in Program.cs

            app.Run();
        }
    }
}