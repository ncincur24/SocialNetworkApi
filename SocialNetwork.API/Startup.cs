
using Bugsnag.AspNet.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocialNetwork.API.ErrorLogging;
using SocialNetwork.API.Validators;
using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.API
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
            /*
                Transient - Svaki put kada se zatrazi objekat, kreira se novi
                Scoped - Ponovna upotreba na nivou 1 http zahteva
                Singleton - jedan objekat od starta do stop-a aplikacije
                
            */

            services.AddBugsnag(configuration => {
                configuration.ApiKey = "a13741fca0d9439871aff65f7c948908";
            });

            services.AddHttpContextAccessor();
            
            services.AddTransient<IErrorLogger>(x =>
            {
                var accesor = x.GetService<IHttpContextAccessor>();

                var logger = accesor.HttpContext.Request.Headers["Logger"].FirstOrDefault();
               
                if(logger == "Console")
                {
                    return new ConsoleErrorLogger();
                } else
                {
                    return new BugSnagErrorLogger(x.GetService<Bugsnag.IClient>());
                }
            });

            services.AddTransient<CreatePostValidator>();
            services.AddTransient<SocialNetworkContext>(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer("Data Source=localhost; Initial Catalog = SocialNetwork1; Integrated Security = true");
                return new SocialNetworkContext(builder.Options);
            });

            services.AddTransient<CreatePostValidator>();
            services.AddTransient<UpdatePostValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<CreateCommentReactionValidator>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialNetwork.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialNetwork.API v1"));
            }

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
