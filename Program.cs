using Microsoft.EntityFrameworkCore;
using SchedulingApi.Controllers;
using SchedulingApi.Model;
using SchedulingApi.Repositories;
using SchedulingApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISchedulingService, SchedulingService>();
builder.Services.AddScoped<ISchedulingRepository, SchedulingRepository>();

builder.Services.AddDbContext<SchedulingContext>(opt => 
    opt.UseSqlite("Filename=.\\Data\\scheduling.db"));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
