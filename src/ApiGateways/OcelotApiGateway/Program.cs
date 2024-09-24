using Common.Logging;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

builder.Configuration.AddJsonFile($"ocelot.{ builder.Environment.EnvironmentName}.json", true, true);
builder.Host.UseSerilog(SeriLogger.Configure);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

await app.UseOcelot();

app.Run();
