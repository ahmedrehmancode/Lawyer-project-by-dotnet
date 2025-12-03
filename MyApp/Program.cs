using Microsoft.EntityFrameworkCore;
using MyApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("Dbconnection")));
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");+


app.MapControllerRoute(
    name: "Home Page",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
