using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudenAdminPortal.Data;
using StudenAdminPortal.Repositery;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Data Source = 10.168.16.78\\MSSQLSRV2019; Initial Catalog = SQLTraining; User ID = AWLDhrishti; Password=AWLDhrishti;Encrypt=False"));

builder.Services.AddScoped<IStudentRepositery, StudentRepositery>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200/").AllowAnyOrigin()
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("angularApplication");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); 



 






