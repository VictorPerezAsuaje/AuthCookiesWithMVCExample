var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", opts =>
{
    // Recommended config
    opts.Cookie.Name = "AuthCookie";
    opts.Cookie.MaxAge = new TimeSpan(00, 30, 00);
    opts.LoginPath = "/Identity/Login";

    // Optional config
    //opts.LogoutPath = "/";
    //opts.AccessDeniedPath = "/403";
    //opts.Cookie.SameSite = SameSiteMode.Strict; 
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
