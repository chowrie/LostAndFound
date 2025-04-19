using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. 注册 Razor Pages
builder.Services.AddRazorPages();

// 2. 注册 EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. 注册邮件服务（QQ SMTP）
builder.Services.AddSingleton(sp =>
{
    var cfg = sp.GetRequiredService<IConfiguration>();
    return new EmailService(
        cfg["EmailSettings:SmtpServer"],
        cfg.GetValue<int>("EmailSettings:SmtpPort"),
        cfg["EmailSettings:SmtpUsername"],
        cfg["EmailSettings:SmtpPassword"]
    );
});

// 4. 注册 Session（前提：AddDistributedMemoryCache）
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 中间件管道
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

// 自定义认证中间件：检查 Session["Email"]
app.UseAuthenticationMiddleware();

// 路由
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
