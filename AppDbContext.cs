using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置关系 (可以省略，EF Core 会自动推断)
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Item)
            .WithMany() // 一个Item可以有多个Message
            .HasForeignKey(m => m.ItemId);

        base.OnModelCreating(modelBuilder);
    }
}
