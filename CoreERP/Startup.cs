using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreERP
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
            services.AddControllers().AddJsonOptions(options =>
            {
               options.JsonSerializerOptions.Converters.Add(new BussinessLogic.Common.JsonValueConvertor<int>());
               options.JsonSerializerOptions.Converters.Add(new BussinessLogic.Common.JsonValueConvertor<decimal>());
               options.JsonSerializerOptions.Converters.Add(new BussinessLogic.Common.JsonValueConvertor<DateTime>());
               options.JsonSerializerOptions.Converters.Add(new BussinessLogic.Common.JsonValueConvertor<string>());
            });
         
            services.AddCors(options =>
            {
                options.AddPolicy("CoreERPCoresPloicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        //builder.AllowAnyHeader();
                        //builder.AllowAnyMethod();
                    }
                    );
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CoreERPCoresPloicy");

            app.UseRouting();

          //  app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
