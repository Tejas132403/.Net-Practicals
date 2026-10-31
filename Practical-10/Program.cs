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

// Enable Swagger and Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
    c.RoutePrefix = "swagger";
});

// Redirect root "/" to "/swagger" so opening the application immediately displays the Swagger API UI
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();

app.MapControllers();

app.Run();
