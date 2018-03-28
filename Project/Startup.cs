using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using Project.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NSwag.AspNetCore;
using System.Reflection;
using NJsonSchema;
using System.IO;

namespace Project
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

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
      })
       .AddJwtBearer("JwtBearer", jwtBearerOptions =>
       {
         jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
         {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("H38DLSIEKD8EKDOS")),
           ValidateIssuer = false,
                 //ValidIssuer = "The name of the issuer",
                 ValidateAudience = false,
                 //ValidAudience = "The name of the audience",
                 ValidateLifetime = true, //validate the expiration and not before values in the token
                 ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
               };
       });
      services.AddMvc()
          .AddRazorPagesOptions(options =>
          {
            options.Conventions.AuthorizeFolder("/Account/Manage");
            options.Conventions.AuthorizePage("/Account/Logout");
          });

      // Register no-op EmailSender used by account confirmation and password reset during development
      // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
      services.AddSingleton<IEmailSender, EmailSender>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }



      // Enable the Swagger UI middleware and the Swagger generator
      app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
      {
        settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
      });

      //app.UseMvc(routes =>
      //{
      //    routes.MapRoute(
      //        name: "default",
      //        template: "{controller}/{action=Index}/{id?}");
      //});

      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 &&
           !Path.HasExtension(context.Request.Path.Value) &&
           !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });
      app.UseMvcWithDefaultRoute();
      app.UseStaticFiles();
      app.UseDefaultFiles();

      app.UseAuthentication();
    }
  }
}
