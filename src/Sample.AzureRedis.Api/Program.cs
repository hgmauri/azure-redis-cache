using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sample.AzureRedis.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
SerilogExtensions.AddSerilog(builder.Configuration);
builder.Host.UseSerilog(Log.Logger);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.UseSwaggerDoc();

app.MapControllers();

app.Run();