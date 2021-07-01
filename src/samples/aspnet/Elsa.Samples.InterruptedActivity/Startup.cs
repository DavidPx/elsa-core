using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.PostgreSql;

namespace Elsa.Samples.InterruptedActivity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddElsa(options =>
                    options.UseEntityFrameworkPersistence(ef => {
                            ef.UsePostgreSql("Server=127.0.0.1;Port=5432;Database=elsa;User Id=postgres;Password=foobar;");
                        })
                        .AddConsoleActivities()
                        .AddWorkflowsFrom<Startup>()
                        .AddActivitiesFrom<Startup>()
                        .AddQuartzTemporalActivities()
                );

            services
                .AddElsaApiEndpoints();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
