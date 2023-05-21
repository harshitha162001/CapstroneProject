using CapstoneProject.DAL;
using CapstoneProject.Models;
using Microsoft.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMedicineService, MidicineService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAdressService, AdressService>();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddControllers();

var app = builder.Build();
builder.Services.AddCors();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
// Configure the HTTP request pipeline.

app.UseAuthorization();


app.MapControllers();

app.Run();