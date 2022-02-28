namespace Refiz.Domain.Views
{
    public partial class WPreparation
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
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public bool Active { get; set; }
        public short TypeOrg { get; set; }
    }
}
