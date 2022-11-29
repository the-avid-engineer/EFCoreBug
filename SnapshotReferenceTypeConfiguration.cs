using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBug;

public class SnapshotReferenceTypeConfiguration : IEntityTypeConfiguration<SnapshotReference>
{
    public virtual void Configure(EntityTypeBuilder<SnapshotReference> snapshotReferenceBuilder)
    {
        snapshotReferenceBuilder.ToTable("SnapshotReferences");

        snapshotReferenceBuilder
            .HasKey(snapshotReference => snapshotReference.Id);

        snapshotReferenceBuilder
            .HasAlternateKey(snapshotReference => new
            {
                snapshotReference.PointerId,
                snapshotReference.PointerVersionNumber
            });

        var snapshotBuilder = snapshotReferenceBuilder
            .HasOne(snapshotReference => snapshotReference.Snapshot);
    }
}

public class SnapshotTypeConfiguration : IEntityTypeConfiguration<Snapshot>
{
    public virtual void Configure(EntityTypeBuilder<Snapshot> snapshotBuilder)
    {
        snapshotBuilder.ToTable("Snapshots");

        snapshotBuilder
            .HasKey(snapshot => new
            {
                snapshot.Id,
                snapshot.VersionNumber,
            });
    }
}
