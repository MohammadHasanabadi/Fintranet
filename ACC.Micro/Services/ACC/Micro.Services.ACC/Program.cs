using MassTransit;
using Micro.Services.ACC.Data;
using Micro.Services.ACC.Repository;
using Micro.Services.ACC.Services;
using HealthChecks.UI.Client;
using Micro.Services.ACC.EventBusConsumer;
using ACC.Bus.Common.Common;
using static GrpcService.Greeter;
using Micro.Services.ACC.GrpcServices;

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
    // Grpc Configuration
    services.AddGrpcClient<GreeterClient>
                (o => o.Address = new Uri(builder.Configuration["GrpcSettings:url"]));
    services.AddScoped<GreatGrpcService>();

    // MassTransit-RabbitMQ Configuration ---Subscriber-----
    services.AddMassTransit(config => {
        config.AddConsumer<CreateUserEventConsumer>();
        config.UsingRabbitMq((ctx, cfg) => {
            cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
            cfg.ReceiveEndpoint(EventBusConstant.CreateUserEventQueue, x =>
            {
                x.ConfigureConsumer<CreateUserEventConsumer>(ctx);
            });
        });
    });



    services.AddScoped<IACCdbContext, AccdbContext>();
    services.AddScoped<IGroupService, GroupService>();
    services.AddScoped<IGroupRepository, GroupRepository>();
    services.AddSwaggerGen();


}