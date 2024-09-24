using Account.Infrastructure;
using Account.Application;
using Microsoft.OpenApi.Models;
using Account.Infrastructure.Persistence;
using Serilog;
using Common.Logging;
using Account.API.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Customer.GRPC.Protos;
using Account.API.GrpcServices;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<CustomerProtoService.CustomerProtoServiceClient>(c => c.Address = new Uri(builder.Configuration["GrpcSettings:CustomerUrl"]!));
builder.Services.AddScoped<CustomerGrpcService>();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMassTransit(conf =>
{
    conf.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]!);
    });
});
builder.Services.Configure<MassTransitHostOptions>(conf =>
{
    conf.WaitUntilStarted = true;
    conf.StartTimeout = TimeSpan.FromSeconds(30);
    conf.StopTimeout = TimeSpan.FromMinutes(1);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Account.API", Version = "v1" });
});
builder.Services.AddHealthChecks()
    .AddRabbitMQ(builder.Configuration["EventBusSettings:HostAddress"]!,name:"accounttransaction-rabbitmqbus")
    .AddDbContextCheck<AccountContext>();
builder.Host.UseSerilog(SeriLogger.Configure);
var app = builder.Build();

app.MigrateDatabase<AccountContext>((context, services) =>
{
    var logger = services.GetService<ILogger<AccountContextSeed>>();
    AccountContextSeed
        .SeedAsync(context, logger!)
        .Wait();
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account.API v1"));
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
