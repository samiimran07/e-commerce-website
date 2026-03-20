using ecommerce_website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Identity ke liye zaroori hai

var builder = WebApplication.CreateBuilder(args);

// 1. Connection String read karein
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. DbContext register karein
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Identity Services Add karein (Week 3 Task)
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false; // Testing ke liye password asaan rakha hai
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 4. MVC aur Razor Pages register karein
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Purani version mein MapStaticAssets ki jagah ye use hota hai

app.UseRouting();

// --- AUTHENTICATION ORDER ---
app.UseAuthentication(); // Pehle pehchan (Who are you?)
app.UseAuthorization();  // Phir ijazat (What can you do?)

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Login/Register pages ke routes register karne ke liye

app.Run();