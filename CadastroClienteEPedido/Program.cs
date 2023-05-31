using CadastroClienteEPedido.Data;
using CadastroClienteEPedido.Repository;
using CadastroClienteEPedido.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

builder.Services.AddCors(options =>
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5500","http://127.0.0.1:5500")
            .SetIsOriginAllowed(isOriginAllowed: _ => true).AllowAnyHeader().AllowAnyMethod();
    })
);

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
void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<CadastroClienteEPedidoDataContext>(
        options =>
            options.UseSqlServer(connectionString));
    builder.Services.AddTransient<ClienteService>();
    builder.Services.AddTransient<ProdutoService>();
    builder.Services.AddTransient<PedidoService>();
    builder.Services.AddTransient<ProdutoRepository>();
    builder.Services.AddTransient<ClienteRepository>();
    builder.Services.AddTransient<PedidoRepository>();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
