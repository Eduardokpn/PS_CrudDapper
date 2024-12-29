using ApiPS.Interface;
using ApiPS.Interfaces;
using ApiPS.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers com Views
builder.Services.AddControllersWithViews();

// Registro dos Repositórios
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

var app = builder.Build();

// Middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Roteamento
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pessoa}/{action=Listar}/{id?}");

app.Run();
