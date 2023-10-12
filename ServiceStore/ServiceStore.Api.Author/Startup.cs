using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Author.Application;
using ServiceStore.Api.Author.Persistence;

namespace ServiceStore.Api.Author;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<NewRequest>());

        services.AddDbContext<AuthorContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DBConnection"));
        });

        services.AddMediatR(typeof(NewRequest.ManagerRequest).Assembly);
        services.AddAutoMapper(typeof(ConsultRequest.ManagerRequest));
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
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