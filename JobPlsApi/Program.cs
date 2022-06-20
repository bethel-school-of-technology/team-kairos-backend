using JobPlsApi.Data;
using JobPlsApi.Helpers;
using JobPlsApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container

var services = builder.Services;

// Connection to Database
services.AddDbContext<AppDbContext>
    (options => options.UseSqlite("Name=AppDb"));

services.AddCors();
services.AddControllers();

// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
services.AddScoped<IUserService, UserService>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();


app.Run();
