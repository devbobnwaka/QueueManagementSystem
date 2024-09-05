using QMSWebAPI.Contracts;
using QMSWebAPI.LoggerService;
using QMSWebAPI.Repository;
using NLog;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using QMSWebAPI.Extentions.ServiceExtensions;
using QMSWebAPI.Extentions;



var builder = WebApplication.CreateBuilder(args);

//LOAD ENVIRONMENT VARIABLE
Env.Load();
// Add services to the container.
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//Service Extensions
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));

string connectionString = builder.Configuration.GetConnectionString("sqlConnection") 
    ?? throw new InvalidOperationException("Connection string 'sqlConnection' not found!!!");
builder.Services.ConfigureDBContextService(connectionString);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
