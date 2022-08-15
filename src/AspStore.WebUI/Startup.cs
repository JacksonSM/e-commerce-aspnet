using AspStore.CrossCutting;
using AspStore.WebUI.Configuration;
using AspStore.WebUI.Extensions.Helpers;
using AspStore.WebUI.Extensions.Identity;
using AspStore.WebUI.Extensions.Identity.Services;
using AspStore.WebUI.Infra;
using AspStore.WebUI.Services.Account;
using AspStore.WebUI.Services.ArquivoCSV;
using AspStore.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspStore.WebUI
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
            services.AddScoped<IGerenciadorImagens, GerenciadorImagens>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IFiltragemCatalago, FiltragemCatalago>();
            services.AddScoped<IManipuladorArquivoCSVCarrossel, ManipuladorArquivoCSVCarrossel>();

            services.AddTransient<IUnitOfUpload, UnitOfUpload>();
            services.AddTransient<IEmailSender, EmailSender>();


            services.Configure<AutenticacaoSender>(options => Configuration.GetSection("AutenticacaoSender").Bind(options));


            services.AddIdentityConfig(Configuration);
            services.AddDbContextService(Configuration);
            services.AddAutoMapperService();
            services.AddRepositoryServices();
            services.AddDomainService();
            services.AddAppService();
            services.AddControllersWithViews();
            services.AddCrossCuttingDependency();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var authMsgSenderOpt = new AutenticacaoSender
            {
                SendGridUser = Configuration["SendGridUser"],
                SendGridKey = Configuration["SendGridKey"]
            };

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
