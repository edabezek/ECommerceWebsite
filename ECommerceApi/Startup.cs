using ECommerceApi.Helpers;
using ECommerceBusinnes.Abstract;
using ECommerceBusinnes.Concrete;
using ECommerceDataAccess;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters { 
            ValidateAudience=true,//token deðerini kimlerin hangi uygulamalrýn kullnacaðýný belirler
            ValidateIssuer=true,//oluþturulan token deðerini kim daðýtmýþtýr(þuan biziz daðýtan)
            ValidateLifetime=true,//oluþturulan tokenýn yaþam süresi
            ValidateIssuerSigningKey=true,//üretilen token deðerinin uygulamamýza ait olup olmadýðý security key'i
            ValidIssuer=Configuration["Token:Issuer"],//burada oluþturulan token deðerini kým daðýtmýþtýra ýssuer demiþtik varsayalým umitdurur.com daðýtmýþ bunu appsettins'e yazacaðýz configuration ile okuyacaðýz. yani yukarýdaki datanýn deðerini appsettings'den almamýza yarayacak
            ValidAudience=Configuration["Token:Audience"],
            IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
            ClockSkew=TimeSpan.Zero //token yenileme yeri eðer 5 belirlemiþsek 5+5 yapar yani token süresinin uzatýlmasýný saðlar
            });


            services.AddMvc().AddRazorPagesOptions(opt=>opt.Conventions.AddPageRoute("/SignIn",""));//Açýlýþ ve yönlendirme,Login açýlýþ sayfasý yaptýk

            services.AddControllers() ;
            services.AddRazorPages();
            services.AddDbContext<EComerceDBAccess>(dbContext => dbContext.UseSqlServer(Configuration.GetConnectionString("LocalDbConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IAdressServices, AdressServices>();
            services.AddScoped<ISellerServices, SellerServices>();
            services.AddTransient<GenericHelperMethods>();

            services.AddSwaggerDocument();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection(); //farklý sayfaya yönlendirme 
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseDefaultFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider=new PhysicalFileProvider(Path.Combine(env.ContentRootPath,"Pages")),RequestPath="/Pages"
            //});
            app.UseStaticFiles();

            app.UseEndpoints(endpoints => //istek sonlandýrma yeri
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
