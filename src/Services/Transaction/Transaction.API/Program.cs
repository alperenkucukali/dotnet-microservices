using Common.Logging;
using EventBus.Messages.Common;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using Transaction.API.Data.Interfaces;
using Transaction.API.EventBusConsumer;
using Transaction.API.Repositories;
using Transaction.API.Repositories.Interfaces;
using Transaction.API.Services;
using Transaction.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(conf =>
{
    conf.AddConsumer<AccountTransactionConsumer>();
    conf.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]!);
        cfg.ReceiveEndpoint(EventBusConstants.AccountTransactionQueue, c =>
        {
            c.ConfigureConsumer<AccountTransactionConsumer>(ctx);
        });
    });
});
builder.Services.Configure<MassTransitHostOptions>(conf =>
{
    conf.WaitUntilStarted = true;
    conf.StartTimeout = TimeSpan.FromSeconds(30);
    conf.StopTimeout = TimeSpan.FromMinutes(1);
});
builder.Services.AddScoped<AccountTransactionConsumer>();
builder.Services.AddScoped<ITransactionContext, Transaction.API.Data.TransactionContext>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Transaction.API", Version = "v1" });
});
builder.Services.AddHealthChecks()
    .AddRabbitMQ(builder.Configuration["EventBusSettings:HostAddress"]!, name: "accounttransaction-rabbitmqbus")
    .AddMongoDb(builder.Configuration["DatabaseSettings:ConnectionString"]!, "MongoDb Health", HealthStatus.Degraded);
builder.Host.UseSerilog(SeriLogger.Configure);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transaction.API v1"));
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
