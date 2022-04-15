namespace Refiz.Domain
{
    public partial class Preparation
    {
        public int Idpreparation { get; set; }
        public int Idorganisation { get; set; }
        public DateTime DateImport { get; set; }
        public short State { get; set; }
        public string Data { get; set; } = null!;
        public DateTime DateStateChange { get; set; }
        public Guid GuidBatch { get; set; }
        public string? Description { get; set; }
        public int NrBatch { get; set; }
        public string? DataSync { get; set; }
        public int VersionXml { get; set; }

        public virtual Organisation IdorganisationNavigation { get; set; } = null!;
    }
}
