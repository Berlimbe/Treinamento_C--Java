using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Treinamento.Web.Data;
using Treinamento.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data
builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/linguagens", async (AppDataContext context) =>
{
    return Results.Ok(await context.Linguagens.ToListAsync());
});

app.MapGet("/api/linguagens/{id}", async (int id, AppDataContext context) =>
{
    var linguagem = await context.Linguagens.FindAsync();
    return linguagem is null ? Results.NotFound() : Results.Ok(linguagem);
});

app.MapPost("/api/linguagens", async (Linguagem linguagem, AppDataContext context) =>
{
    context.Linguagens.Add(linguagem);
    await context.SaveChangesAsync();
    return Results.Created($"/api/linguagens/{linguagem.Id}", linguagem);
});

app.MapPut("/api/linguagem/{id}", async (int id, Linguagem linguagemAtualizada, AppDataContext context) =>
{
    var linguagemExistente = await context.Linguagens.FindAsync(id);
    if (linguagemExistente is null)
    {
        return Results.NotFound();
    }
    linguagemExistente.Nome = linguagemAtualizada.Nome;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/linguagens/{id}", async (int id, AppDataContext context) =>
{
    var linguagem = await context.Linguagens.FindAsync(id);
    if (linguagem is null) {
        return Results.NotFound();
    }
    context
    .Linguagens.Remove(linguagem);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPost("/api/informacoes", async (Informacao informacao, AppDataContext context) =>
{
    // Verificar se a LinguagemId existe antes de adicionar a informação
    var linguagemExiste = await context.Linguagens.AnyAsync(l => l.Id == informacao.LinguagemId);
    if (!linguagemExiste)
    {
        return Results.BadRequest("LinguagemId fornecida não existe.");
    }

    context.Informacoes.Add(informacao);
    await context.SaveChangesAsync();
    return Results.Created($"/informacoes/{informacao.Id}", informacao);
});

app.Run();