using MedicalLabratoryManagment.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
    );


var types = Assembly.GetExecutingAssembly().GetTypes();
var serviceTypes = types
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"));

// Register each service type
foreach (var serviceType in serviceTypes) {
    var interfaceType = types.FirstOrDefault(t => t.IsInterface && t.Name == "I" + serviceType.Name);
    // Register as a transient service
    if (interfaceType != null) {
        builder.Services.AddTransient(interfaceType, serviceType);
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
