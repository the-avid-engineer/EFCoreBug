namespace EFCoreBug;

public class SnapshotReference
{
    public required Guid Id { get; init; }

    public required Guid PointerId { get; init; }

    public required ulong PointerVersionNumber { get; init; }

    public required Snapshot Snapshot { get; set; }
}
