// Remove any stale staticwebassets manifest generated with old paths before CreateBuilder reads it
try
{
    var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name ?? "StudentManagementAPI";
    var staleManifest = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.staticwebassets.runtime.json");
    if (File.Exists(staleManifest))
    {
        File.Delete(staleManifest);
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
