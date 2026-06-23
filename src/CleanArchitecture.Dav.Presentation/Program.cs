using CleanArchitecture.Dav.Infrastructure;
using CleanArchitecture.Dav.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddPresentationLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.RegisterEndpoints();

await app.Services.MigrateDatabaseAsync();

app.Run();