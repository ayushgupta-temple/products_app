using ProductsApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<Product[]>(new Product[]
{
    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();