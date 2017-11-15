using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapi.Data;
using webapi.Models;
using Hasty.ApiGenerator.Extensions;


namespace webapi
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
            services.AddDbContext<HastyDataContext>();
            services.AddHasty();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using(var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<HastyDataContext>();

                if (!dbContext.Person.Any())
                {
                    var persons = new List<Person>
                    {
                        new Person { Id = 1, FirstName = "waqas", LastName = "khan" },
                        new Person { Id = 2, FirstName = "waqas", LastName = "khan" },
                        new Person { Id = 3, FirstName = "waqas", LastName = "khan" },
                        new Person { Id = 4, FirstName = "waqas", LastName = "khan" },
                     };

                    dbContext.Person.AddRange(persons);
                    dbContext.SaveChanges();
                }
            }
            app.UseHastyApi<HastyDataContext>();          
        }
    }
}
