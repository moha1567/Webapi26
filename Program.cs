using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICES ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// tar bort "if (app.Environment.IsDevelopment())" så att du kan se sidan på AWS
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Krypterings API V1");
    c.RoutePrefix = string.Empty; 
});

// kommenterar bort HTTPS-redirection eftersom AWS ofta hanterar detta i sin lastbalanserare
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Enkel hälsningsfras för att se att allt lever
app.MapGet("/status", () => "Welcome to the encryption converter, created by Muhammad Sheik Ali. \nThe system works flawless and running in AWS so have  fun converting!");



// OMVANDLARE: Text -> Base64
app.MapPost("/encrypt", (string text) => {
    if (string.IsNullOrWhiteSpace(text)) return "Vänligen skriv in lite text att omvandla.";

    byte[] textBytes = Encoding.UTF8.GetBytes(text);
    string base64Text = Convert.ToBase64String(textBytes);

    return $"Base64-kod: {base64Text}";
});

// OMVANDLARE: Base64 -> Text
app.MapPost("/decrypt", (string base64Text) => {
    try
    {
        if (string.IsNullOrWhiteSpace(base64Text)) return "Vänligen klistra in en Base64-kod.";

        byte[] decodedBytes = Convert.FromBase64String(base64Text);
        string originalText = Encoding.UTF8.GetString(decodedBytes);

        return $"Originaltext: {originalText}";
    }
    catch
    {
        return "Fel: Kunde inte avkoda texten. Kontrollera att det är giltig Base64.";
    }
});

app.Run();