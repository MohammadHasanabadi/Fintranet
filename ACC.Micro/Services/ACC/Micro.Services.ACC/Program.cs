using MassTransit;
using Micro.Services.ACC.Data;
using Micro.Services.ACC.Repository;
using Micro.Services.ACC.Services;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfiguServices(builder.Services);


builder.Services.AddControllers();




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




void ConfiguServices(IServiceCollection services)
{

    // MassTransit-RabbitMQ Configuration ---Subscriber-----
    services.AddMassTransit(config => {
        config.UsingRabbitMq((ctx, cfg) => {
            cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

            //cfg.UseHealthCheck(ctx);
        });
    });

    //services.AddMassTransitHostedService();


    services.AddScoped<IACCdbContext, AccdbContext>();
    services.AddScoped<IGroupService, GroupService>();
    services.AddScoped<IGroupRepository, GroupRepository>();
    services.AddSwaggerGen();


}