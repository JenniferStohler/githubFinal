using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace FinalProject.Server
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
      services.AddAuthentication();
      services.AddControllers();

      //TODO TRANSIENT SERVICES
      //TODO TRANSIENT REPOS
      //   [epic= DB]
      services.AddScoped<IDbConnection>(x => CreateDbConnection());
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinalProject.Server", Version = "v1" });
      });
    }

    private IDbConnection CreateDbConnection()
    {
      String connectionString = Configuration["DB:gearhost"];
      return new MySqlConnection(connectionString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalProject.Server v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseAuthentication();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
