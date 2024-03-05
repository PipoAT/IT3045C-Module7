var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Urls.Add("http://localhost:5555");

app.MapGet("/", () => {

return "Hello World!";

});

app.Run();
