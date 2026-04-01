using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Data;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create;
using Ness_Mizarhi_Zeev_Test.Core.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MathOperationsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MathOperationsConnection")));


builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssemblyContaining<CalculateOperationCommandValidator>();

builder.Services.AddHttpClient("ExternalApi", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Write-side abstraction
builder.Services.AddScoped<IWriteDbContext>(provider =>
    provider.GetRequiredService<MathOperationsDbContext>());

// Read-side abstraction
builder.Services.AddScoped<IReadDbContext>(provider =>
    provider.GetRequiredService<MathOperationsDbContext>());

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
