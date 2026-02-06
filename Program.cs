var builder = WebApplication.CreateBuilder(args);

// Lägg till services för API och Swagger
builder.Services.AddControllers(); // Lägg till detta för att stödja controllers
builder.Services.AddEndpointsApiExplorer(); // Lägg till för att kunna skapa Swagger
builder.Services.AddSwaggerGen(); // Lägg till för att generera Swagger/OpenAPI-dokumentation

var app = builder.Build();

// Aktivera Swagger UI i utvecklingsmiljö
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Generera Swagger-dokumentation
    app.UseSwaggerUI(); // Visa Swagger UI
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Detta mappar alla controllers, t.ex. EncryptionController

app.Run();
