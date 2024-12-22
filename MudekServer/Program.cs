using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudekServer.Data;
using MudekServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// WeatherForecastService'i Singleton olarak ekliyoruz
builder.Services.AddSingleton<WeatherForecastService>();

// DbContext'i Scoped olarak ekliyoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity servislerini ekliyoruz
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// LessonService ve LoPoMatrixService Scoped olarak ekleniyor
builder.Services.AddScoped<LessonService>();
builder.Services.AddScoped<LoPoMatrixService, LoPoMatrixService>();
builder.Services.AddScoped<StudentService>();

// HttpClient'i server-side için ekliyoruz
builder.Services.AddHttpClient();  // Burada HttpClient'i ekliyoruz

// SinavTurService Scoped olarak ekleniyor
builder.Services.AddScoped<SinavTurService>();

// Middleware'leri yapılandırıyoruz
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection(); // HTTP -> HTTPS yönlendirmesi
app.UseStaticFiles(); // Statik dosyaları sunma
app.UseRouting(); // Routing işlemini etkinleştirme

// Blazor uygulamasını çalıştırıyoruz
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
