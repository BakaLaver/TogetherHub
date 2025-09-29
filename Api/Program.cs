var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiService(builder.Configuration)
    .AddInfrastructureService(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.UseApiServices();

app.Run();
