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
            .OwnsOne(snapshotReference => snapshotReference.Snapshot);

        Configure(snapshotBuilder);
    }

    protected virtual void Configure(OwnedNavigationBuilder<SnapshotReference, Snapshot> snapshotBuilder)
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
