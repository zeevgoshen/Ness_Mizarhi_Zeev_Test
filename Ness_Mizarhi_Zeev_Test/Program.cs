using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ness_Mizarhi_Zeev_Test.Core.Data;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// zeev - I added the controllers with views, as I will be using the MVC pattern for this project.
// I also added MediatR for handling the CQRS pattern, and I added an HttpClient for making
// requests to the external API. Finally, I added Swagger for API documentation and testing.
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddDbContext<MathOperationsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MathOperationsConnection")));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));



builder.Services.AddHttpClient("ExternalApi", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

// zeev - I added the endpoints API explorer and SwaggerGen for API documentation and testing.


builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IWriteDbContext>(provider =>
    provider.GetRequiredService<MathOperationsDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute(); //
app.MapControllers();

app.Run();
