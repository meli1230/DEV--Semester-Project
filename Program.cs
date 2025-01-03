using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MelisaIuliaProiect.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options => {options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));}); //admin authorization policy

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MelisaIuliaProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MelisaIuliaProiectContext") ?? throw new InvalidOperationException("Connection string 'MelisaIuliaProiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MelisaIuliaProiectContext") ?? throw new InvalidOperationException("Connection string 'MelisaIuliaProiectContext' not found")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

//authorization for cars
builder.Services.AddRazorPages(options => { 
    options.Conventions.AuthorizeFolder("/Cars");  //authorization for cars folder
    options.Conventions.AllowAnonymousToPage("/Cars/Index"); //allow anonymous users
    options.Conventions.AllowAnonymousToPage("/Cars/Details"); //allow anonymous users
    options.Conventions.AuthorizeFolder("/VehicleModels", "AdminPolicy"); //admin only can access customers models folder
    options.Conventions.AuthorizeFolder("/VehicleTypes", "AdminPolicy"); //admin only can access customers types folder
    options.Conventions.AuthorizeFolder("/Equipments", "AdminPolicy"); //admin only can access customers equipments folder
    options.Conventions.AuthorizeFolder("/Transmissions", "AdminPolicy"); //admin only can access customers transmissions folder
    options.Conventions.AuthorizeFolder("/Fuels", "AdminPolicy"); //admin only can access customers fuels folder
    options.Conventions.AuthorizeFolder("/Sellers", "AdminPolicy"); //admin only can access sellers folder
    options.Conventions.AuthorizeFolder("/Customers", "AdminPolicy"); //admin only can access customers folder
});

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
