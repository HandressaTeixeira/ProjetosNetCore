using Microsoft.EntityFrameworkCore;
using MiniValidation;
using Produtos.Api.Data;
using Produtos.Api.Entidades;
using Produtos.Api.ViewModels;

#region Startup

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Contexto>();

#region Informa??es do AppSettings
Configuracoes.StringConexao = builder.Configuration["StringConexao"];
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#endregion

//-------------------------------------M?todos da api------------------------------------

#region M?todos da api

#region Produtos

app.MapGet("/Produtos/Listar", async (Contexto _contexto) =>
    await _contexto.Produto.OrderBy(x => x.Nome).ToListAsync())
.WithName("ListarProdutos")
.WithTags("Produtos");

app.MapGet("/Produtos/BuscarPorId/{id}",
    async (Guid id, Contexto _contexto) =>
    await _contexto.Produto.FirstOrDefaultAsync(x => x.Id == id)
        is Produto produto ?
            Results.Ok(produto) : Results.NotFound())
    .Produces<Produto>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("BuscarProdutoPorId")
    .WithTags("Produtos");


app.MapPost("/Produtos/Inserir",
    async (InserirProdutoViewModel model, Contexto _contexto) =>
    {
        if (!MiniValidator.TryValidate(model, out var errors))
            return Results.ValidationProblem(errors);

        var produto = new Produto(model.Nome, model.Descricao, model.FornecedorId);
        _contexto.Produto.Add(produto);
        var resultado = await _contexto.SaveChangesAsync();

        return resultado > 0
            ? Results.CreatedAtRoute("BuscarProdutoPorId", new { id = produto.Id }, produto)
            : Results.BadRequest("Houve um problema ao inserir um novo fornecedor");
    })
    .Produces<Fornecedor>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest)
    .WithName("InserirProduto")
    .WithTags("Produtos");

app.MapPut("/Produtos/Atualizar",
    async (AtualizarProdutoViewModel model, Contexto _contexto) =>
    {
        if (!MiniValidator.TryValidate(model, out var errors))
            return Results.ValidationProblem(errors);

        if (!_contexto.Produto.Any(x => x.Id == model.Id))
            return Results.NotFound("Produto n?o encontrado");

        if (!_contexto.Fornecedor.Any(x => x.Id == model.FornecedorId))
            return Results.NotFound("Fornecedor n?o encontrado");

        _contexto.Produto.Update(new Produto(model.Id, model.Nome, model.Descricao, model.FornecedorId));
        var resultado = await _contexto.SaveChangesAsync();

        return resultado > 0
            ? Results.NoContent()
            : Results.BadRequest("Houve um problema ao atualizar o produto");
    })
    .ProducesValidationProblem()
    .Produces<Fornecedor>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest)
    .WithName("AtualizarProduto")
    .WithTags("Produtos");


app.MapDelete("/Produtos/Deletar/{id}",
    async (Guid id, Contexto _contexto) =>
    {
        var fornecedor = await _contexto.Produto.FirstOrDefaultAsync(x => x.Id == id);

        if (fornecedor == null)
            return Results.NotFound("Fornecedor n?o encontrado");

        _contexto.Produto.Remove(fornecedor);
        var resultado = await _contexto.SaveChangesAsync();

        return resultado > 0
            ? Results.NoContent()
            : Results.BadRequest("Houve um problema ao deletar o produto");
    })
    .Produces<Fornecedor>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("DeletarProdutoPorId")
    .WithTags("Produtos");

#endregion

#region Fornecedores

app.MapGet("/Fornecedores/Listar", async (Contexto _contexto) =>
    await _contexto.Fornecedor.OrderBy(x => x.Nome).ToListAsync())
.WithName("ListarFornecedores")
.WithTags("Fornecedores");

app.MapGet("/Fornecedores/BuscarPorId/{id}",
    async (Guid id, Contexto _contexto) =>
    await _contexto.Fornecedor.FirstOrDefaultAsync(x => x.Id == id)
        is Fornecedor fornecedor ?
            Results.Ok(fornecedor) : Results.NotFound())
    .Produces<Fornecedor>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("BuscarFornecedorPorId")
    .WithTags("Fornecedores");

app.MapPost("/Fornecedores/Inserir",
    async (InserirFornecedorViewModel model, Contexto _contexto) =>
    {
        if (!MiniValidator.TryValidate(model, out var errors))
            return Results.ValidationProblem(errors);

        var fornecedor = new Fornecedor(model.Nome, model.Email);
        _contexto.Fornecedor.Add(fornecedor);
        var resultado = await _contexto.SaveChangesAsync();

        return resultado > 0
            ? Results.CreatedAtRoute("BuscarFornecedorPorId", new { id = fornecedor.Id }, fornecedor)
            : Results.BadRequest("Houve um problema ao inserir um novo fornecedor");
    })
    .Produces<Fornecedor>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest)
    .WithName("InserirFornecedor")
    .WithTags("Fornecedores");

app.MapPut("/Fornecedores/Atualizar",
    async (AtualizarFornecedorViewModel model, Contexto _contexto) =>
    {
        if (!MiniValidator.TryValidate(model, out var errors))
            return Results.ValidationProblem(errors);

        if (!_contexto.Fornecedor.Any(x => x.Id == model.Id))
            return Results.NotFound("Fornecedor n?o encontrado");

        _contexto.Fornecedor.Update(new Fornecedor(model.Id, model.Nome, model.Email));
        var resultado = await _contexto.SaveChangesAsync();

        return resultado > 0
            ? Results.NoContent()
            : Results.BadRequest("Houve um problema ao atualizar o fornecedor");
    })
    .ProducesValidationProblem()
    .Produces<Fornecedor>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest)
    .WithName("AtualizarFornecedor")
    .WithTags("Fornecedores");

app.MapDelete("/Fornecedores/Deletar/{id}",
    async (Guid id, Contexto _contexto) =>
    {
        var fornecedor = await _contexto.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);

        if (fornecedor == null)
            return Results.NotFound("Fornecedor n?o encontrado");

        if (_contexto.Produto.Any(x => x.FornecedorId == id))
            return Results.BadRequest("Este fornecedor possui produtos v?nculados e n?o pode ser deletado");

        _contexto.Fornecedor.Remove(fornecedor);
        var resultado = await _contexto.SaveChangesAsync();

        return resultado > 0
            ? Results.NoContent()
            : Results.BadRequest("Houve um problema ao deletar o fornecedor");
    })
    .Produces<Fornecedor>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("DeletarFornecedorPorId")
    .WithTags("Fornecedores");
#endregion

#endregion


//-------------------------------------Run-----------------------------------------------
app.Run();