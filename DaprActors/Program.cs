using DaprActors;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json")
     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
     .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddDaprClient();
#if DEBUG
builder.Services.AddDaprSidekick(configuration);
#endif
builder.Services.AddActors(options =>
{
    options.Actors.RegisterActor<SeatSelectorActor>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Add actor endpoints.
app.MapActorsHandlers();

app.Run();
