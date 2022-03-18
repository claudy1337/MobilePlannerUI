using Microsoft.EntityFrameworkCore;
using MobilePlanner.Application.Interfaces;
using MobilePlanner.Persistence;

var builder = WebApplication.CreateBuilder(args);
//(builder.Configuration.GetConnectionString("PlannerConnection")))
var connection = builder.Configuration.GetConnectionString("PlannerConnection");
builder.Services.AddDbContext<PlannerDBContext>(opt => opt.
    UseSqlServer(connection,builder => builder.MigrationsAssembly("MobilePlanner.WebApi")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlannerRepository, MockPlannerRepository>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
