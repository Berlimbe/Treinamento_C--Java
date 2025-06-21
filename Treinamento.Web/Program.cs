using Microsoft.EntityFrameworkCore;
using Treinamento.Web.Data; //ta com erro no reconhecimento do data
using Treinamento.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data
builder.Services.AddDbContext<AppDataContext>(options => //aqui também ta com erro no reconhecimento do AppDataContext
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

