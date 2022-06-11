using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Test_API
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
            services.AddControllers();

            string connstr = this.Configuration.GetConnectionString("dbConnection");

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connstr));
            services.AddCors();

            //services.AddSwaggerGen(setup =>
            //{
            //    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "UniEmailSender.API", Version = "v1" });
            //});

            //services.AddScoped<ICustomerDal, DpCustomerDal>()
            //       .AddScoped<ICustomerService, CustomerManager>()
            //       .AddScoped<ISupplierService, SupplierManager>()
            //       .AddScoped<ISupplierDal, DpSupplierDal>()
            //       .AddScoped<IProductService, ProductManager>()
            //       .AddScoped<IProductDal, DpProductDal>()
            //       .AddScoped<IStockService, StockManager>()
            //       .AddScoped<IStockDal, DpStockDal>()
            //       .AddScoped<ISaleService, SaleManager>()
            //       .AddScoped<ISaleDal, DpSaleDal>()
            //       .AddScoped<IReturnService, ReturnManager>()
            //       .AddScoped<IReturnDal, DpReturnDal>()
            //       .AddTransient<IDbConnection>(db => conn)
            //       .AddScoped<Form1>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
