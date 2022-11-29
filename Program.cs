using EFCoreBug;
using Microsoft.EntityFrameworkCore;

// INSERT
{
    using var dbContext = new MyDbContext();

    var dbSet = dbContext.Set<SnapshotReference>();

    dbSet.Add(new SnapshotReference
    {
        Id = Guid.NewGuid(),
        PointerId = Guid.NewGuid(),
        PointerVersionNumber = 0,
        Snapshot = new Snapshot
        {
            Id = Guid.NewGuid(),
            VersionNumber = 1,
        }
    });

    dbContext.SaveChanges();
}

// DELETE ALL
{
    using var dbContext = new MyDbContext();

    var dbSet = dbContext.Set<SnapshotReference>();

    // ATTENTION!
    // This throws ArgumentOutOfRangeException!

    dbSet
        .Where(blog => true)
        .ExecuteDelete();
}
