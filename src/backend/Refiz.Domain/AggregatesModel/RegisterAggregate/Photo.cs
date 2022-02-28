namespace Refiz.Domain.AggregatesModel.RegisterAggregate
{
    public partial class Photo
    {
        public int Idphoto { get; set; }
        public int Idregister { get; set; }
        public string ContentType { get; set; } = null!;
        public string? Note { get; set; }
        public string HashCode { get; set; } = null!;
        public int Index { get; set; }

        public virtual Register IdregisterNavigation { get; set; } = null!;
    }
}
