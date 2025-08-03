var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<http_project.repository.ram_storage.Task.ITask, http_project.repository.ram_storage.Task.Task>();
builder.Services.AddTransient<http_project.usecases.Task.ITask, http_project.usecases.Task.Task>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();