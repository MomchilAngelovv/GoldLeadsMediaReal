namespace GoldLeadsMedia.CoreApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using GoldLeadsMedia.Database;
    using GoldLeadsMedia.Database.Models;
    using GoldLeadsMedia.CoreApi.Filters;
    using GoldLeadsMedia.CoreApi.Services.Brokers;
    using GoldLeadsMedia.CoreApi.Services.AsyncHttpClient;
    using GoldLeadsMedia.CoreApi.Services.Common;
    using GoldLeadsMedia.CoreApi.Services;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(
            IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Controllers
            services.AddControllers(options => 
            {
                options.Filters.Add<RegisterDeveleporErrorExceptionFilter>();
            });

            //Cors
            services.AddCors();

            //Database
            services.AddDbContext<GoldLeadsMediaDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
            });

            //Identity
            services.AddIdentity<GoldLeadsMediaUser, GoldLeadsMediaRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
           .AddEntityFrameworkStores<GoldLeadsMediaDbContext>()
           .AddDefaultTokenProviders();

            //Http client
            services.AddHttpClient();
            services.AddTransient<IAsyncHttpClient, AsyncHttpClient>();

            //CoreApi Services
            services.AddTransient<IOfferGroupsService, OfferGroupsService>();
            services.AddTransient<ILanguagesService, LanguagesService>();
            services.AddTransient<ITargetDevicesService, TargetDevicesService>();
            services.AddTransient<IAccessesService, AccessesService>();
            services.AddTransient<IPayTypesService, PayTypesService>();
            services.AddTransient<IVerticalsService, VerticalsService>();
            services.AddTransient<ICountriesService, CountriesService>();
            services.AddTransient<IOffersService, OffersService>();
            services.AddTransient<ILeadsService, LeadsService>();
            services.AddTransient<IClicksRegistrationsService, ClicksRegistrationsService>();
            services.AddTransient<ILandingPagesService, LandingPagesService>();
            services.AddTransient<IBrokersService, BrokersService>();
            services.AddTransient<IManagersService, ManagersService>();
            services.AddTransient<IAffiliatesService, AffiliatesService>();
            services.AddTransient<IErrorsService, ErrorsService>();
            services.AddTransient<ICountryTiersService, TierCountriesService>();

            //Brokers
            services.AddTransient<ProfitPixelsBroker>();
            services.AddTransient<TestBroker>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
