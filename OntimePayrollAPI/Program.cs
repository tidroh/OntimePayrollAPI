using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTER SERVICES
builder.Services.AddControllers(); // Required to find your Payroll controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure connection to your restored OntimePayroll database
builder.Services.AddDbContext<OntimePayrollContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. CONFIGURE PIPELINE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 3. MAP ROUTES
app.MapControllers(); // Required to map incoming API requests to controllers

app.Run();