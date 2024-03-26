using APIInjDependencias.Implementations;
using APIInjDependencias.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedSingleton<ITesteDI, TesteDI>("SingletonA");
builder.Services.AddKeyedSingleton<ITesteDI, TesteDI>("SingletonB", (_, _) => new TesteDI());

builder.Services.AddKeyedScoped<ITesteDI, TesteDI>("ScopedA");
builder.Services.AddKeyedScoped<ITesteDI, TesteDI>("ScopedB");

builder.Services.AddKeyedTransient<ITesteDI, TesteDI>("TransientA");
builder.Services.AddKeyedTransient<ITesteDI, TesteDI>("TransientB");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();