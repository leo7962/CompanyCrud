using CompanyCrud.Helpers;
using Core.Interfaces;
using Infrastructure.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<EmployeeRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CompanyCrud", Version = "v1",
        Description = "This a project to consume an external api Restfull",
        Contact = new OpenApiContact
        {
            Email = "ingenieroleonardo@outlook.com",
            Name = "Leonardo Fabián Hernández Peña",
            Url = new Uri("https://github.com/leo7962")
        },
        License = new OpenApiLicense
        {
            Name = "GPL-3.0"
        }
    });
    x.OperationFilter<AddParameterHateoas>();
    x.OperationFilter<AddParameterXVersion>();
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdmin", policy => policy.RequireClaim("isAdmin"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsRule",
        rule => rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();