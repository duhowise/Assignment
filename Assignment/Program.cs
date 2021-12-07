using System.Text.Json;
using System.Text.Json.Serialization;
using Assignment.Domain.Behaviour;
using Assignment.Extensions;
using Assignment.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("application started");
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(hostBuilderContext.Configuration));


    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        })
        .ConfigureApiBehaviorOptions(options => {
            options.InvalidModelStateResponseFactory = ctx =>
            {
                var allErrors = ctx.ModelState.Values
                    .SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

                Log.Information("error occurred",allErrors);
                return new BadRequestObjectResult(allErrors);
            };
        }); ;


    builder.Services.AddMediatR(typeof(Program).Assembly);
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddHttpClient("ProductClient", httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://www.mocky.io");
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Log.Information("Fatal error application failed",e);
    Log.CloseAndFlush();
}