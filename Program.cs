using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. ע�� Razor Pages
builder.Services.AddRazorPages();

// 2. ע�� EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. ע���ʼ�����QQ SMTP��
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

// 4. ע�� Session��ǰ�᣺AddDistributedMemoryCache��
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// �м���ܵ�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

// �Զ�����֤�м������� Session["Email"]
app.UseAuthenticationMiddleware();

// ·��
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
