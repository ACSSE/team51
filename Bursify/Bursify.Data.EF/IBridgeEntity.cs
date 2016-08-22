namespace Bursify.Data.EF
{
    public interface IBridgeEntity
    {
        int leftId { get; }
        int rightId { get; }
    }
}
