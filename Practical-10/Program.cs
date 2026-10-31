// Ensure temporary obj asset directories exist to prevent DirectoryNotFoundException in preview SDKs
try
{
    var jsModulesPath = Path.Combine(Directory.GetCurrentDirectory(), "obj", "Debug", "net10.0", "jsmodules");
    if (!Directory.Exists(jsModulesPath))
    {
        Directory.CreateDirectory(jsModulesPath);
    }
}
catch { }

var builder = WebApplication.CreateBuilder(args);

// Register controller services
builder.Services.AddControllers();

// Register API Explorer and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
