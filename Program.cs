var builder = WebApplication.CreateBuilder(args);

// 1. Lägg till tjänster
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. VIKTIGT: Ta bort "if (app.Environment.IsDevelopment())" 
// Vi vill att Swagger ska synas även på AWS (Production) så vi kan testa
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI26 V1");
    c.RoutePrefix = string.Empty; // Detta gör att Swagger blir startsidan på AWS!
});

// 3. Kommentera bort HttpsRedirection tillfälligt
// AWS sköter HTTPS åt dig, och denna rad kan krocka med AWS interna inställningar
// app.UseHttpsRedirection(); 

app.UseAuthorization();
app.MapControllers();

// Lägg till detta precis innan app.Run();
app.MapGet("/hello", () => "Hej från AWS!");

app.MapPost("/encrypt", (string text) => {
    // Här lägger du din krypteringslogik
    return $"Krypterat: {text}_secret";
});

app.Run();