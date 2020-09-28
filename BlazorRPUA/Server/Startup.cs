using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;


namespace BlazorRPUA.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDB>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("EFDB")));


            //DB kontext koji se odnosi na Identity
            services.AddDbContext<EFDBID>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("EFDB")));

            //Ovdje koristimo IdentityUser IdentityRole
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddUserManager<UserManager<IdentityUser>>()
                .AddSignInManager<SignInManager<IdentityUser>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EFDBID>();

            services.AddIdentityServer()
                .AddApiAuthorization<IdentityUser, EFDBID>(options =>
                {
                    options.IdentityResources["openid"].UserClaims.Add("korisnicko");
                    options.ApiResources.Single().UserClaims.Add("korisnicko");

                    options.IdentityResources["openid"].UserClaims.Add("role");
                    options.ApiResources.Single().UserClaims.Add("role");
                });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

            services.AddAuthentication().AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            
            //https nam je neophodan za bezbjednost
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
                endpoints.MapHub<Hubs.PrimalacUHub>("PrimalacUHub");
                endpoints.MapHub<Hubs.KorisnikIdHub>("KorisnikIdHub");
            });
        }
    }
}
