namespace Scafold
{
    public partial class WEntity
    {
        public int Identity { get; set; }
        public bool Active { get; set; }
        public bool IsFirm { get; set; }
        public string FullName { get; set; } = null!;
        public string? FirmName { get; set; }
        public string Address { get; set; } = null!;
        public int Idrole { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateActivated { get; set; }
        public string Email { get; set; } = null!;
        public int Idcountry { get; set; }
        public int? Idregion { get; set; }
        public string NameRole { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public string? RegionName { get; set; }
        public int? Idorganisation { get; set; }
        public string? OrganisationName { get; set; }
    }
}
