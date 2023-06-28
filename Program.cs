using POSSystem.Entities;
using POSSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IOrdersRepository, InMemOrdersRepository>();

var app = builder.Build();


app.MapOrdersEndpoints();

app.Run();
