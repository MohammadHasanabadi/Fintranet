using Microsoft.EntityFrameworkCore;
using Store.Application;
using Store.Infrastructure;
using Store.Infrastructure.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
ConfigureServices(builder.Services);



builder.Services.AddControllers();

var app = builder.Build();

var config = builder.Configuration;


// Configure the HTTP request pipeline.

ConfigureMiddleware(app);

//var db = app.Services.GetRequiredService<StoreContext>();
//db.Database.MigrateAsync();


app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
    db.Database.EnsureCreated();
   
}


app.Run();



void ConfigureServices(IServiceCollection Services)
{
    Services.AddSwaggerGen();
    Services.AddApplicationDependency();
    Services.AddInfrastructureServices(builder.Configuration);

}

void ConfigureMiddleware(WebApplication app)
{
    app.UseSwaggerUI();
    app.UseSwagger(x => x.SerializeAsV2 = true);

}