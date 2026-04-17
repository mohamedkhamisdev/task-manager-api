using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseInMemoryDatabase("TaskManagerDb"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
