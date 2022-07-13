using CodingSchool;
using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    return context.Response.WriteAsync(File.ReadAllText("htmlpage.html"));
});

app.MapGet("/color", async (int index) =>
{
    var client = new HttpClient();

    var path = $"http://dev035:3022/index/{index}";

    HttpResponseMessage response = await client.GetAsync(path);
    if (response.IsSuccessStatusCode)
    {
        var data = await response.Content.ReadFromJsonAsync<DataResponse>();
        return data != null ? data.Color : "Unknown";
    }
    return "Unknown";
});

app.Run();
