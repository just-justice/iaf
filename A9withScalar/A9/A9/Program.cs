using Microsoft.EntityFrameworkCore;
using A9.Data;
using Swashbuckle.AspNetCore.SwaggerGen;
using Scalar.AspNetCore;
using Microsoft.OpenApi.Models;
using AspNetCore.Scalar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add CORS policy for the front-end
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add Swagger 
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Add DbContext for PostgreSQL
builder.Services.AddDbContext<A9DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Enable CORS
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "A9 API V1");
        c.RoutePrefix = "swagger"; // Prevents conflicts with Scalar
    });

    // Enable Scalar API Reference UI
    app.MapScalarApiReference();
}


app.UseScalar();

app.UseAuthorization();
app.MapControllers();

app.Run();
