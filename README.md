Välkommen! Det här är ett litet projekt jag byggt för att lära mig hur man skapar ett API med .NET och får ut det på nätet med AWS.

Vad gör den?
Det här är en enkel "kodmaskin" som använder något som kallas för Base64.

Du kan skicka in vanlig text (som ditt namn) och få ut en "hemlig" kod.

Du kan klistra in koden igen och få tillbaka din ursprungliga text.

Det är perfekt för att skicka data som innehåller konstiga tecken som annars skulle kunna förstöra en länk eller en databas.

Var finns den?
Appen ligger live på AWS: HÄR KAN DU TESTA DEN (Klicka på rutorna "Encrypt" eller "Decrypt" och tryck på "Try it out" för att testa själv!)
http://webapi26-env.eba-9zfrehg8.eu-north-1.elasticbeanstalk.com/

Hur funkar det under huven?
Varje gång jag sparar min kod och skickar upp den till GitHub, så händer detta automatiskt:

Den skickar upp paketet till AWS Elastic Beanstalk, så att min hemsida alltid är uppdaterad utan att jag behöver göra något manuellt i AWS.

Tekniker jag använt:
C# / .NET 10 för själva logiken.

Swagger för att göra det enkelt att testa API:et direkt i webbläsaren.

GitHub Actions för att sköta automatisk uppladdning (CI/CD).

AWS för att hosta appen på riktigt.
