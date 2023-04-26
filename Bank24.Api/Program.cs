using Bank24.Core;
using Bank24.Core.AccountAggregate;
using Tactical.DDD.EventSourcing.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CoreAssembly).Assembly));

builder.Services.AddScoped<IAccountRepo, AccountRepo>();

builder.Services.AddPostgresEventStore("Host=localhost;Database=instahelp;Username=anes.hasicic");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.EnsurePostgresEventStoreCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();