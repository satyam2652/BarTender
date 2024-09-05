using Core;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<ICocktailClient>(new CocktailClient(builder.Configuration["CocktailClient:BaseUrl"]));
builder.Services.AddControllers().AddNewtonsoftJson();



Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Is(LogEventLevel.Debug)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddSingleton(Log.Logger);
builder.Host.UseSerilog(Log.Logger);

var app = builder.Build();
app.UseSerilogRequestLogging();
app.MapControllers();
app.Run();
app.UseSerilogRequestLogging();
Log.CloseAndFlush();
