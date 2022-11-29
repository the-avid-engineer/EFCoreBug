using Microsoft.EntityFrameworkCore;

namespace EFCoreBug;

internal class MyDbContext : DbContext
{
    private readonly string _dbPath;

    public MyDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);

        _dbPath = Path.Join(path, "test3.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SnapshotReferenceTypeConfiguration());
    }
}
