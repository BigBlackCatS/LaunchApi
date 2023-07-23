using LaunchApi.ApiClients.v1;
using LaunchApi.Extensions;
using LaunchApi.Middlewares;
using LaunchApi.Profilers.v1;
using LaunchApi.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureVersioning();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var launchesEndpoint = builder.Configuration.GetValue<string>("LaunchEndpoint") ?? string.Empty;

builder.Services.AddScoped<ILaunchesService, LaunchesService>();
builder.Services.AddAutoMapper(m => {
    m.AddProfile<DomainToContractProfile>();
});

builder.Services.AddHttpClient<ILaunchesApiClient, LaunchesApiClient>((client) =>
{
    client.BaseAddress = new Uri(launchesEndpoint);
});

builder.Logging.ClearProviders();
builder.WebHost.UseNLog();

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure
app.UseCors("AnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }

        c.DisplayRequestDuration();
    });
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
