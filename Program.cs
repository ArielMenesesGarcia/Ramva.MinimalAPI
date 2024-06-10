using API.Minimal.Application.Mapper;
using API.Minimal.Infrastructre;
using API.Minimal.Presentation.RoutesExtensions;
using API.Minimal.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MinimalDB>( opc => opc.UseInMemoryDatabase("DBInMemory"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile)); 
builder.Services.AddSingleton<LoggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.AddRoutesColimaServices(); // Operaciones para Colima
app.AddRoutesUsuarios(); // Operaciones para Usuarios


app.Run();
 
