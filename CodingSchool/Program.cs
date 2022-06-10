using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    return context.Response.WriteAsync(File.ReadAllText("htmlpage.html"));
});

app.MapGet("/color", (int index) =>
{
    switch (index)
    {
        case 1: return "Red";
        case 2: return "Orange";
        case 3: return "Black";
        case 4: return "Blue";
        case 5: return "Purple";
        case 6: return "Green";
        case 7: return "Brown";
        case 8: return "Yellow";
        case 9: return "White";
        case 10: return "Gray";
    }
    return "Unknown";
});

app.Run();
