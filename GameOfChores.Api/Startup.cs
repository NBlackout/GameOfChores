using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Application.UseCases.AddChoreType;
using GameOfChores.Application.UseCases.GetChoreTypes;
using GameOfChores.Data;
using GameOfChores.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameOfChores.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddDbContext<GameOfChoresContext>(o => o.UseInMemoryDatabase("GameOfChores"));
            services.AddScoped<IChoreTypeRepository, ChoreTypeRepository>();
            services.AddScoped<IGetChoreTypes, GetChoreTypes>();
            services.AddScoped<IAddChoreType, AddChoreType>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
