using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("", (HttpContext context) =>
{
    var html = System.IO.File.ReadAllText("htmlpage.html");
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    return context.Response.WriteAsync(html);
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
