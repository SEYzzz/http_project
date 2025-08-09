using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<http_project.repository.ram_storage.Task.ITask, http_project.repository.ram_storage.Task.Task>();
builder.Services.AddTransient<http_project.usecases.Task.ITask, http_project.usecases.Task.Task>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();