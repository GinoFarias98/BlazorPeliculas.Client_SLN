using BlazorPeliculas.Client;
using BlazorPeliculas.Client.Repositorios;
using BlazorPeliculas.Client.Servicios;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
ConfigureServices(builder.Services);
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<IHttpServicio, HttpServicio>();

await builder.Build().RunAsync();

//Configuracion de servicios
void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IRepositorio, Repositorio>();
}