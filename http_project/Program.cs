using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<http_project.repository.ram_storage.Task.ITask, http_project.repository.ram_storage.Task.Task>();
builder.Services.AddTransient<http_project.usecases.Task.ITask, http_project.usecases.Task.Task>();

builder.Services.AddSingleton<http_project.repository.ram_storage.User.IUser, http_project.repository.ram_storage.User.User>();
builder.Services.AddTransient<http_project.usecases.User.IUser, http_project.usecases.User.User>();

builder.Services.AddSingleton<http_project.repository.ram_storage.Session.ISession, http_project.repository.ram_storage.Session.Session>();
builder.Services.AddTransient<http_project.usecases.Session.ISession, http_project.usecases.Session.Session>();

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