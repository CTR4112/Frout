using System;
using System.Threading.Tasks;
using frout_implementation.Application;
using frout_implementation.Application.Implementation;
using frout_implementation.Domain.Repositories;
using frout_implementation.Infrastructure;
using frout_implementation.Infrastructure.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace frout_implementation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader();
                });
            });

            services.AddControllers();

            // because it is scoped, they are destroyed after request (will be recreated in next request)
            services.AddScoped<IDeliveryService, DeliveryMVPService>();
            services.AddScoped<ISubscriptionRepository, EFCoreSubscriptionRepository>();
            services.AddScoped<IFarmerRepository, EFCoreFarmerRepository>();

            services.AddDbContext<FroutDbContext>(
                //opt => opt.UseSqlServer(Configuration.GetConnectionString("FroutDB")) // In case of Microsoft SQL-Server
                opt => opt.UseMySql(
                    Configuration.GetConnectionString("FroutDB"),
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("FroutDB")))
                //_connectionString,
                //ServerVersion.AutoDetect(_connectionString))
                //.LogTo(Console.WriteLine)
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "froutDB_backend", Version = "v1" });
            });

            //https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
            services.AddControllers();
                //.AddNewtonsoftJson(options =>
                //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FroutDbContext _context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "froutDB_backend"));
            }

            _context.Database.Migrate(); // like dotnet ef database update

            //seeding entries (initially fill db with testdata)
            Task.WaitAll(SeedDB.InitializeAsync(_context));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
