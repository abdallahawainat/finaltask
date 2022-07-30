using learn.core.domain;
using learn.core.Repository;
using learn.core.service;
using learn.infra.domain;
using learn.infra.Repository;
using learn.infra.service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finaltask
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
            services.AddScoped<IDBcontext, DBcontext>();

            services.AddScoped<Iuser_apirepository, user_apirepositoty>();
            services.AddScoped<Iloginuser_apirepository, loginuser_apirepository>();
            services.AddScoped<Isendmessage_repository, sendmessage_repository>();
            services.AddScoped<Iaddfriend_repository, addfriend_repository>();
            services.AddScoped<Igetfriends_repository, getfriends_repository>();
            services.AddScoped<Ipost_apirepository, post_apirepository>();

            services.AddScoped<Iuser_apiservice, user_apiservice>();
            services.AddScoped<Iloginuser_apiservice, loginuser_apiservice>();
            services.AddScoped<Isendmessage_service, sendmessage_service>();
            services.AddScoped<Iaddfriend_service, addfriend_service>();
            services.AddScoped<Igetfriends_service, getfriends_service>();
            services.AddScoped<Ipost_apiservice, post_apiservice>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

           ).AddJwtBearer(y =>
           {
               y.RequireHttpsMetadata = false;
               y.SaveToken = true;
               y.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                   ValidateIssuer = false,
                   ValidateAudience = false,

               };


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
