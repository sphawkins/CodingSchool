using System.Data.SqlClient;
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
    string? returnValue = "Unknown";
    try
    {
        var connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CodingSchool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        var connection = new SqlConnection(connetionString);
        connection.Open();
        var cmd = new SqlCommand($"select Color from Colors where Id = {index}", connection);
        var scalar = cmd.ExecuteScalar();
        if (scalar != null)
        {
            returnValue = scalar as string;
        }
    }
    catch (Exception ex)
    {
        returnValue = "Error";
    }
    return returnValue;
});

app.Run();
