using Insurance.Application;
using Insurance.Application.Contracts;
using Insurance.Application.Middleware;
using Insurance.infrastructure;
using Insurance.infrastructure.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExeptionsManager>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
