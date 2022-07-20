
using Account.Application;
using Account.Infrastructure;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions();

builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependency();

builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();


builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.AutoStart = true;
        //cfg.Publish<IServerNotificationMessage>(e => e.ExchangeType = RabbitMQ.Client.ExchangeType.Direct);

    });
});




var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
