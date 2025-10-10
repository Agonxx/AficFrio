using AficFrio.Api.Bases;
using AficFrio.Api.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.SetupDatabase(builder.Configuration);
builder.Services.SetupRepositories();
builder.Services.SetupServices();
builder.Services.SetupSwagger();
builder.Services.SetupCORS();
builder.Services.AddSignalR();
builder.Services.SetupJwt();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
