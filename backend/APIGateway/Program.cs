using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOcelot();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(builder.Configuration["AllowedOrigins"])
            .WithHeaders(builder.Configuration["AllowedHeaders"])
            .WithMethods(builder.Configuration.GetSection("AllowedMethods").Value.Split(','));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

await app.UseOcelot();

app.Run();
