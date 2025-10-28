using AficFrio.Api.Bases;
using AficFrio.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.SetupDatabase(builder.Configuration);
builder.Services.SetupRepositories();
builder.Services.SetupServices();
builder.Services.SetupSwagger();
builder.Services.SetupCORS();
builder.Services.AddSignalR();
builder.Services.SetupJwt();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
