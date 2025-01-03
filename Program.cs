using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MelisaIuliaProiect.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MelisaIuliaProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MelisaIuliaProiectContext") ?? throw new InvalidOperationException("Connection string 'MelisaIuliaProiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MelisaIuliaProiectContext") ?? throw new InvalidOperationException("Connection string 'MelisaIuliaProiectContext' not found")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

//authorization for cars
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Cars"); }); //authorization for cars folder
builder.Services.AddRazorPages(options => { options.Conventions.AllowAnonymousToPage("/Cars/Index"); }); //allow anonymous users
builder.Services.AddRazorPages(options => { options.Conventions.AllowAnonymousToPage("/Cars/Details"); }); //allow anonymous users

//authorization for models
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Models"); }); //authorization for models folder

//authorization for equipments
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Equipments"); }); //authorization for equipments folder

//authorization for transmissions
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Transmissions"); }); //authorization for transmissions folder

//authorization for fuels
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Fuels"); }); //authorization for fuels folder

//authorization for sellers
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Sellers"); }); //authorization for sellers folder

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
